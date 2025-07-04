using EnergyPortal.Application.Sites.Commands.CreateSite;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public interface ISitesService
{
	Task<Site> GetSite(Guid id);
	Task<Guid> UpdateSite(Guid id, CreateSiteCommand site);
	Task<Guid> DeleteSite(Guid id);
}
