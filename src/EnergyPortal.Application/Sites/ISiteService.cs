using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public interface ISiteService
{
	Task<List<Site>> GetSites();
	Task<Site> AddSite(Site site);
}
