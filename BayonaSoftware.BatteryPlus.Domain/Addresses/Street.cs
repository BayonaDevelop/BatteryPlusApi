namespace BayonaSoftware.BatteryPlus.Domain.Addresses;

public class Street
{
	public int ColonyId { get; set; }
	public long Id { get; set; }
	public string Name { get; set; } = null!;

	public virtual Colony Colony { get; set; } = null!;
	public virtual ICollection<Address> AddressStreets { get; set; } = new List<Address>();
	public virtual ICollection<Address> AddressStreetsA { get; set; } = new List<Address>();
	public virtual ICollection<Address> AddressStreetsB { get; set; } = new List<Address>();
}
