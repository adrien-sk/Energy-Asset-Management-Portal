namespace EnergyPortal.Domain.Assets;

public class Battery : Asset
{
	public decimal CurrentCharge { get; private set; }
	public decimal ChargeCapacity { get; private set; }
	public decimal MaxChargeRate { get; private set; }
	public decimal MaxDischargeRate { get; private set; }
	public int CycleCount { get; private set; }
	public decimal StateOfHealth { get; private set; } // Battery health percentage (0-1)
	public decimal? Temperature { get; private set; } // Current temperature in Celsius

	// Private constructor for EF Core
	private Battery() { }
}
