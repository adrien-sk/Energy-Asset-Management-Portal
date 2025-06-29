namespace EnergyPortal.Domain.Sites;

public interface ISiteRepository
{
	Task<List<Site>> GetSites();
	Task<Site> AddSite(Site site);
}
