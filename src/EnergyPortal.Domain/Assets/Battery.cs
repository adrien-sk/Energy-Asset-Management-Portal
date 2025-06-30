namespace EnergyPortal.Domain.Assets;

public class Battery : Asset
{
	public decimal CurrentCharge { get; set; }
	public decimal ChargeCapacity { get; set; }
	public decimal MaxChargeRate { get; set; }
	public decimal MaxDischargeRate { get; set; }
	public int CycleCount { get; set; }
	public decimal StateOfHealth { get; set; } // Battery health percentage (0-1)
	public decimal? Temperature { get; set; } // Current temperature in Celsius
}
