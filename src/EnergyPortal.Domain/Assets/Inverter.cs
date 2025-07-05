using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Assets;

public class Inverter : Asset
{
	public decimal DCInput { get; private set; }
	public decimal ACOutput { get; private set; }
	public decimal DCVoltage { get; private set; }
	public decimal ACVoltage { get; private set; }
	public decimal Frequency { get; private set; } // AC frequency in Hz
	public decimal? Temperature { get; private set; } // Temperature in Celsius

	private Inverter() { }

	internal Inverter(
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
		string createdBy) : base(siteId, status, type, capacity, installationDate, manufacturer, model, createdBy)
	{
		DCInput = dcInput;
		ACOutput = acOutput;
		DCVoltage = dcVoltage;
		ACVoltage = acVoltage;
		Frequency = frequency;
		Temperature = temperature;
	}

	public void Update(
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
		string updatedBy)
	{
		DCInput = dcInput;
		ACOutput = acOutput;
		DCVoltage = dcVoltage;
		ACVoltage = acVoltage;
		Frequency = frequency;
		Temperature = temperature;

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
