namespace BayonaSoftware.BatteryPlus.Domain.Addresses;

public class Country
{
	public int Id { get; set; }
	public string? Code { get; set; }
	public string? CodeIso2 { get; set; }
	public string Name { get; set; } = null!;
	public string? PostalCodeRegex { get; set; }
	public string? SatRegistryRegex { get; set; }
	public string? Region { get; set; }
	public string? CoatOfArms { get; set; }
	public string? Flag { get; set; }

	public virtual ICollection<City>? Cities { get; set; }
}
