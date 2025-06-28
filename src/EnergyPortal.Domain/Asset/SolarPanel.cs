namespace EnergyPortal.Domain.Asset;

public class SolarPanel : Asset
{
	public decimal TiltAngle { get; private set; }
	public decimal Azimuth { get; private set; }

	// Private constructor for EF Core
	private SolarPanel() { }
}
