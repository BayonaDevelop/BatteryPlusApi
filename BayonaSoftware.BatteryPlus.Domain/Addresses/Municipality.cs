namespace BayonaSoftware.BatteryPlus.Domain.Addresses;

public class Municipality
{
	public int CityId { get; set; }
	public int Id { get; set; }
	public string? Code { get; set; }
	public string Name { get; set; } = null!;
	public string? CoatOfArms { get; set; }

	public virtual City City { get; set; } = null!;
	public virtual ICollection<Location>? Locations { get; set; }
}
