namespace EnergyPortal.Domain.Assets;

public class SolarPanel : Asset
{
	public decimal TiltAngle { get; set; } = decimal.Zero;
	public decimal Azimuth { get; set; } = decimal.Zero;

}
