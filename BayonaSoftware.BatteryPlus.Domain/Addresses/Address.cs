namespace BayonaSoftware.BatteryPlus.Domain.Addresses;

public class Address
{
	public int Id { get; set; }
	public long StreetId { get; set; }
	public long? StreetAid { get; set; }
	public long? StreetBid { get; set; }
	public string? InternalNumber { get; set; }
	public string? ExternalNumber { get; set; }
	public string? Reference { get; set; }

	public virtual Street Street { get; set; } = null!;
	public virtual Street? StreetA { get; set; }
	public virtual Street? StreetB { get; set; }
	public DateTime CreationDate { get; set; }
}
