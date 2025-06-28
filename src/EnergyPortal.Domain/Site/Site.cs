using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Site;

public class Site : BaseEntity
{
	public string Name { get; private set; } = string.Empty;
	public Location? Location { get; private set; }
	public Capacity? TotalCapacity { get; private set; }
	public DateTime? InstallationDate { get; private set; }

	// Private constructor for EF Core
	private Site() { }
}
