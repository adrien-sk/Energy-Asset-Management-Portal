namespace EnergyPortal.Domain.Assets;

public class Inverter : Asset
{
	public decimal DCInput { get; set; }
	public decimal ACOutput { get; set; }
	public decimal DCVoltage { get; set; }
	public decimal ACVoltage { get; set; }
	public decimal Frequency { get; set; } // AC frequency in Hz
	public decimal? Temperature { get; set; } // Temperature in Celsius
}
