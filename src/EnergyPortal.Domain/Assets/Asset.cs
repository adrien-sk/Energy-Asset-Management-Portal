using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Assets;
public abstract class Asset : BaseEntity
{
	public string Name { get; protected set; } = string.Empty;
	public AssetStatus Status { get; protected set; }
	public AssetType Type { get; protected set; }
	public Capacity Capacity { get; protected set; } = default!;
	public Guid SiteId { get; protected set; } = default!;
	public DateTime InstallationDate { get; protected set; }
	public string Manufacturer { get; protected set; } = string.Empty;
	public string Model { get; protected set; } = string.Empty;
}