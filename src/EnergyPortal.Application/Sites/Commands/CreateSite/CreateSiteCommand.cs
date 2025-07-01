namespace EnergyPortal.Application.Sites.Commands.CreateSite;

public class CreateSiteCommand
{
	public string Name { get; set; } = string.Empty!;
	public decimal Latitude { get; set; }
	public decimal Longitude { get; set; }
	public string Address { get; set; } = default!;
	public string City { get; set; } = default!;
	public string Region { get; set; } = default!;
}
