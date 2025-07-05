using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Assets;

public class Battery : Asset
{
	public decimal CurrentCharge { get; private set; }
	public decimal ChargeCapacity { get; private set; }
	public decimal MaxChargeRate { get; private set; }
	public decimal MaxDischargeRate { get; private set; }
	public int CycleCount { get; private set; } = 0;
	public decimal StateOfHealth { get; private set; } // Battery health percentage (0-1)
	public decimal? Temperature { get; private set; } // Current temperature in Celsius

	private Battery() { }

	internal Battery(
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
		string createdBy) : base(siteId, status, type, capacity, installationDate, manufacturer, model, createdBy)
	{
		CurrentCharge = currentCharge;
		ChargeCapacity = chargeCapacity;
		MaxChargeRate = maxChargeRate;
		MaxDischargeRate = maxDischargeRate;
		CycleCount = cycleCount;
		StateOfHealth = stateOfHealth;
		Temperature = temperature;

	}

	public void Update(
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
		string updatedBy)
	{
		CurrentCharge = currentCharge;
		ChargeCapacity = chargeCapacity;
		MaxChargeRate = maxChargeRate;
		MaxDischargeRate = maxDischargeRate;
		CycleCount = cycleCount;
		StateOfHealth = stateOfHealth;
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
