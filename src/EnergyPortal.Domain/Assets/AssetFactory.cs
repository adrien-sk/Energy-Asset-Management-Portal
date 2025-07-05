using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Assets;

public class AssetFactory
{
	public static async Task<SolarPanel> CreateSolarPanel(
		decimal tiltAngle,
		decimal azimuth,
		Guid siteId,
		AssetStatus status,
		AssetType type,
		Capacity capacity,
		DateTime installationDate,
		string manufacturer,
		string model,
		string createdBy)
	{
		return new SolarPanel(
			tiltAngle,
			azimuth,
			siteId,
			status,
			type,
			capacity,
			installationDate,
			manufacturer,
			model,
			createdBy);
	}

	public static async Task<Battery> CreateBattery(
		decimal currentCharge,
		decimal chargeCapacity,
		decimal maxChargeRate,
		decimal maxDischargeRate,
		int cycleCount,
		decimal stateOfHealth,
		decimal temperature,
		Guid siteId,
		AssetStatus status,
		AssetType type,
		Capacity capacity,
		DateTime installationDate,
		string manufacturer,
		string model,
		string createdBy)
	{
		return new Battery(
			currentCharge,
			chargeCapacity,
			maxChargeRate,
			maxDischargeRate,
			cycleCount,
			stateOfHealth,
			temperature,
			siteId,
			status,
			type,
			capacity,
			installationDate,
			manufacturer,
			model,
			createdBy);
	}

	public static async Task<Inverter> CreateInverter(
		decimal dcInput,
		decimal acOutput,
		decimal dcVoltage,
		decimal acVoltage,
		decimal frequency,
		decimal temperature,
		Guid siteId,
		AssetStatus status,
		AssetType type,
		Capacity capacity,
		DateTime installationDate,
		string manufacturer,
		string model,
		string createdBy)
	{
		return new Inverter(
			dcInput,
			acOutput,
			dcVoltage,
			acVoltage,
			frequency,
			temperature,
			siteId,
			status,
			type,
			capacity,
			installationDate,
			manufacturer,
			model,
			createdBy);
	}
}