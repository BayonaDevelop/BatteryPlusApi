using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BayonaSoftware.BatteryPlus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddressesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Addresses");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CodeIso2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCodeRegex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SatRegistryRegex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoatOfArms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoatOfArms = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_City", x => x.ID);
                    table.ForeignKey(
                        name: "fk_City_Country",
                        column: x => x.CountryID,
                        principalSchema: "Addresses",
                        principalTable: "Country",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                schema: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoatOfArms = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Municipality", x => x.ID);
                    table.ForeignKey(
                        name: "fk_Municipality_City",
                        column: x => x.CityId,
                        principalSchema: "Addresses",
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Addresses",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Location", x => x.ID);
                    table.ForeignKey(
                        name: "fk_Location_Municipality",
                        column: x => x.MunicipalityId,
                        principalSchema: "Addresses",
                        principalTable: "Municipality",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Colony",
                schema: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Colony", x => x.ID);
                    table.ForeignKey(
                        name: "fk_Colony_Location",
                        column: x => x.LocationId,
                        principalSchema: "Addresses",
                        principalTable: "Location",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Street",
                schema: "Addresses",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColonyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Street", x => x.ID);
                    table.ForeignKey(
                        name: "fk_Street_Colony",
                        column: x => x.ColonyId,
                        principalSchema: "Addresses",
                        principalTable: "Colony",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    StreetID = table.Column<long>(type: "bigint", nullable: false),
                    StreetAID = table.Column<long>(type: "bigint", nullable: true),
                    StreetBID = table.Column<long>(type: "bigint", nullable: true),
                    InternalNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExternalNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Address", x => x.ID);
                    table.ForeignKey(
                        name: "fk_Address_Street",
                        column: x => x.StreetID,
                        principalSchema: "Addresses",
                        principalTable: "Street",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_Address_StreetA",
                        column: x => x.StreetAID,
                        principalSchema: "Addresses",
                        principalTable: "Street",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_Address_StreetB",
                        column: x => x.StreetBID,
                        principalSchema: "Addresses",
                        principalTable: "Street",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetAID",
                schema: "Addresses",
                table: "Address",
                column: "StreetAID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetBID",
                schema: "Addresses",
                table: "Address",
                column: "StreetBID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetID",
                schema: "Addresses",
                table: "Address",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                schema: "Addresses",
                table: "City",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Colony_LocationId",
                schema: "Addresses",
                table: "Colony",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_MunicipalityId",
                schema: "Addresses",
                table: "Location",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_CityId",
                schema: "Addresses",
                table: "Municipality",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_ColonyId",
                schema: "Addresses",
                table: "Street",
                column: "ColonyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "Addresses");

            migrationBuilder.DropTable(
                name: "Street",
                schema: "Addresses");

            migrationBuilder.DropTable(
                name: "Colony",
                schema: "Addresses");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Addresses");

            migrationBuilder.DropTable(
                name: "Municipality",
                schema: "Addresses");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Addresses");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Addresses");
        }
    }
}
