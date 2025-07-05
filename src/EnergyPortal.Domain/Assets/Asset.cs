using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Assets;

public abstract class Asset : BaseEntity
{
	public Guid SiteId { get; protected set; } = default!;
	public AssetStatus Status { get; protected set; }
	public AssetType Type { get; protected set; }
	public Capacity Capacity { get; protected set; } = default!;
	public DateTime InstallationDate { get; protected set; }
	public string Manufacturer { get; protected set; } = string.Empty!;
	public string Model { get; protected set; } = string.Empty!;

	protected Asset() { }

	protected Asset(
		Guid siteId,
		AssetStatus status,
		AssetType type,
		Capacity capacity,
		DateTime installationDate,
		string manufacturer,
		string model,
		string createdBy) : base(createdBy)
	{
		SiteId = siteId;
		Status = status;
		Type = type;
		Capacity = capacity;
		InstallationDate = installationDate;
		Manufacturer = manufacturer;
		Model = model;
	}

	public void Update(
		AssetStatus status,
		AssetType type,
		Capacity capacity,
		DateTime installationDate,
		string manufacturer,
		string model,
		string updatedBy)
	{
		Status = status;
		Type = type;
		Capacity = capacity;
		InstallationDate = installationDate;
		Manufacturer = manufacturer;
		Model = model;

		SetUpdated(updatedBy);
	}
}