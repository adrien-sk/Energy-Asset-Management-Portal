namespace EnergyPortal.Domain.Sites;

public class SiteFactory
{
	public static async Task<Site> CreateSite(
		string name,
		Location location,
		//Capacity totalCapacity,
		string createdBy)
	{
		// Add here Business rules for Site creation if needed

		return new Site(name, location, /*totalCapacity,*/ createdBy);
	}
}
