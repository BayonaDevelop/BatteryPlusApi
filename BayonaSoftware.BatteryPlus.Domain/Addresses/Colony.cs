namespace BayonaSoftware.BatteryPlus.Domain.Addresses;

public class Colony
{
	public long LocationId { get; set; }
	public int Id { get; set; }
	public string? ZipCode { get; set; }
	public string Name { get; set; } = null!;
	public string? Type { get; set; }

	public virtual Location Location { get; set; } = null!;
	public virtual ICollection<Street>? Streets { get; set; }
}
