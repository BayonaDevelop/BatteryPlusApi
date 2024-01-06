namespace BayonaSoftware.BatteryPlus.Domain.Addresses;

public class City
{
	public int CountryId { get; set; }
	public int Id { get; set; }	
	public string? Code { get; set; }
	public string Name { get; set; } = null!;
	public string? CoatOfArms { get; set; }

	public virtual Country Country { get; set; } = null!;
	public virtual ICollection<Municipality>? Municipalities { get; set; }
}
