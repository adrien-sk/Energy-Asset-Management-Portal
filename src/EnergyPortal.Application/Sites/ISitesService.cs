using EnergyPortal.Application.Sites.Commands.CreateSite;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public interface ISitesService
{
	Task<IEnumerable<Site>> GetSites();
	Task<Site> GetSite(Guid id);
	Task<Guid> CreateSite(CreateSiteCommand site);
	Task<Guid> UpdateSite(Guid id, CreateSiteCommand site);
	Task<Guid> DeleteSite(Guid id);
}
