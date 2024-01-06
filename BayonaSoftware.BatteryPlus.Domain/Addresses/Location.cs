namespace BayonaSoftware.BatteryPlus.Domain.Addresses;

public class Location
{
	public long Id { get; set; }
	public int MunicipalityId { get; set; }
	public int Code { get; set; }
	public string Name { get; set; } = null!;
	public string ZoneType { get; set; } = null!;
	public Municipality Municipality { get; set; } = null!;
	public virtual ICollection<Colony> Colonies { get; set; } = new List<Colony>();
}
