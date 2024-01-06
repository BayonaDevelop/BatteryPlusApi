using BayonaSoftware.BatteryPlus.Domain.Addresses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BayonaSoftware.BatteryPlus.Infrastructure.Persistence
{
	public class MssqlBatteryPlusDbContext : IdentityDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=BatteryPlus;User id=sa;Password=sql;Integrated Security=False;TrustServerCertificate=true");
			}
		}

		public DbSet<Country> Countries { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Municipality> Municipalities { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Colony> Colonies { get; set; }
		public DbSet<Street> Streets { get; set; }
		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Country>(entity =>
			{
				entity.ToTable("Country", "Addresses");
				entity.HasKey(e => e.Id).HasName("pk_Country");

				entity.Property(e => e.Id)
							.HasColumnName("ID");

				entity.Property(e => e.Code)
								.HasMaxLength(3);

				entity.Property(e => e.CodeIso2)
								.HasMaxLength(2);

				entity.Property(e => e.PostalCodeRegex)
								.IsRequired(false);

				entity.Property(e => e.SatRegistryRegex)
								.IsRequired(false);

				entity.Property(e => e.Region)
								.IsRequired(false);

				entity.Property(e => e.CoatOfArms)
								.IsRequired(false);

				entity.Property(e => e.Flag)
								.IsRequired(false);
			});

			builder.Entity<City>(entity =>
			{
				entity.ToTable("City", "Addresses");

				entity.HasKey(e => e.Id)
								.HasName("pk_City");

				entity.Property(e => e.Id)
								.HasColumnName("ID");

				entity.Property(e => e.Code)
								.HasMaxLength(3);

				entity.Property(e => e.CountryId)
								.HasColumnName("CountryID");

				entity.Property(e => e.CoatOfArms)
								.IsRequired(false);

				entity.HasOne(external => external.Country).WithMany(child => child.Cities)
								.HasForeignKey(external => external.CountryId)
								.OnDelete(DeleteBehavior.ClientSetNull)
								.HasConstraintName("fk_City_Country");
			});

			builder.Entity<Municipality>(entity =>
			{
				entity.ToTable("Municipality", "Addresses");

				entity.HasKey(e => e.Id)
								.HasName("pk_Municipality");

				entity.Property(e => e.Id)
								.HasColumnName("ID");

				entity.Property(e => e.CoatOfArms)
								.IsRequired(false);

				entity.HasOne(external => external.City).WithMany(child => child.Municipalities)
								.HasForeignKey(external => external.CityId)
								.OnDelete(DeleteBehavior.ClientSetNull)
								.HasConstraintName("fk_Municipality_City");
			});

			builder.Entity<Location>(entity =>
			{
				entity.ToTable("Location", "Addresses");

				entity.HasKey(e => e.Id)
								.HasName("pk_Location");

				entity.Property(e => e.Id)
								.HasColumnName("ID");

				entity.Property(e => e.ZoneType)
								.IsRequired(false);

				entity.HasOne(external => external.Municipality).WithMany(child => child.Locations)
								.HasForeignKey(external => external.MunicipalityId)
								.OnDelete(DeleteBehavior.ClientSetNull)
								.HasConstraintName("fk_Location_Municipality");
			});

			builder.Entity<Colony>(entity =>
			{
				entity.ToTable("Colony", "Addresses");

				entity.HasKey(e => e.Id)
								.HasName("pk_Colony");

				entity.Property(e => e.Id)
								.HasColumnName("ID");

				entity.Property(e => e.Type)
								.IsRequired(false);

				entity.HasOne(external => external.Location).WithMany(child => child.Colonies)
								.HasForeignKey(external => external.LocationId)
								.OnDelete(DeleteBehavior.ClientSetNull)
								.HasConstraintName("fk_Colony_Location");
			});

			builder.Entity<Street>(entity =>
			{
				entity.ToTable("Street", "Addresses");

				entity.HasKey(e => e.Id)
								.HasName("pk_Street");

				entity.Property(e => e.Id)
								.HasColumnName("ID");

				entity.HasOne(external => external.Colony).WithMany(child => child.Streets)
								.HasForeignKey(external => external.ColonyId)
								.OnDelete(DeleteBehavior.ClientSetNull)
								.HasConstraintName("fk_Street_Colony");
			});

			builder.Entity<Address>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("pk_Address");

				entity.ToTable("Address", "Addresses");

				entity.Property(e => e.Id)
								.HasColumnName("ID")
								.ValueGeneratedNever();

				entity.Property(e => e.ExternalNumber)
								.HasMaxLength(30);

				entity.Property(e => e.InternalNumber)
								.HasMaxLength(30);

				entity.Property(e => e.StreetAid)
								.HasColumnName("StreetAID");

				entity.Property(e => e.StreetBid)
								.HasColumnName("StreetBID");

				entity.Property(e => e.StreetId)
								.HasColumnName("StreetID");

				entity.HasOne(external => external.Street).WithMany(child => child.AddressStreets)
								.HasForeignKey(external => external.StreetId)
								.OnDelete(DeleteBehavior.ClientSetNull)
								.HasConstraintName("fk_Address_Street")
								.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(external => external.StreetA).WithMany(child => child.AddressStreetsA)
								.HasForeignKey(external => external.StreetAid)
								.HasConstraintName("fk_Address_StreetA")
								.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(external => external.StreetB).WithMany(child => child.AddressStreetsB)
								.HasForeignKey(external => external.StreetBid)
								.HasConstraintName("fk_Address_StreetB")
								.OnDelete(DeleteBehavior.ClientSetNull);
			});
		}
	}
}
