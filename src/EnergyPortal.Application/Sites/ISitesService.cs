using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public interface ISitesService
{
	Task<IEnumerable<Site>> GetSites();
	Task<Site> GetSite(Guid id);
	Task<Guid> CreateSite(Site site);
	Task<Guid> UpdateSite(Guid id, Site site);
	Task<Guid> DeleteSite(Guid id);
}
