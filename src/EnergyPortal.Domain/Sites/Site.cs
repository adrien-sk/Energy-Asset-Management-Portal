using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Sites;

public class Site : BaseEntity
{
	public string Name { get; private set; } = string.Empty;
	public Location? Location { get; private set; }
	public Capacity? TotalCapacity { get; private set; }
	public DateTime? InstallationDate { get; private set; }

	// Private constructor for EF Core
	//private Site() { }

	public Site(string name, Location location, Capacity totalCapacity)
	{
		Location = location;
		Name = name;
		TotalCapacity = totalCapacity;
		InstallationDate = DateTime.Now;
	}
}
