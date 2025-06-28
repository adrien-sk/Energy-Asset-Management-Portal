namespace EnergyPortal.Domain.Asset;

public class Inverter : Asset
{
	public decimal DCInput { get; private set; }
	public decimal ACOutput { get; private set; }
	public decimal DCVoltage { get; private set; }
	public decimal ACVoltage { get; private set; }
	public decimal Frequency { get; private set; } // AC frequency in Hz
	public decimal? Temperature { get; private set; } // Temperature in Celsius

	// Private constructor for EF Core
	private Inverter() { }
}
