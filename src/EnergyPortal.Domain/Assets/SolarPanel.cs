using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Assets;

public sealed class SolarPanel : Asset
{
	public decimal TiltAngle { get; private set; } = decimal.Zero;
	public decimal Azimuth { get; private set; } = decimal.Zero;

	private SolarPanel() { }

	internal SolarPanel(
		decimal tiltAngle,
		decimal azimuth,
		Guid siteId,
		AssetStatus status,
		AssetType type,
		Capacity capacity,
		DateTime installationDate,
		string manufacturer,
		string model,
		string createdBy) : base(siteId, status, type, capacity, installationDate, manufacturer, model, createdBy)
	{
		TiltAngle = tiltAngle;
		Azimuth = azimuth;
	}

	public void Update(
		decimal tiltAngle,
		decimal azimuth,
		AssetStatus status,
		AssetType type,
		Capacity capacity,
		DateTime installationDate,
		string manufacturer,
		string model,
		string updatedBy)
	{
		TiltAngle = tiltAngle;
		Azimuth = azimuth;

		Update(
			status,
			type,
			capacity,
			installationDate,
			manufacturer,
			model,
			updatedBy);
	}
}
