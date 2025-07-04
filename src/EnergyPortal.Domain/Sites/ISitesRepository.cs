namespace EnergyPortal.Domain.Sites;

public interface ISitesRepository
{
	Task<IEnumerable<Site>> GetSites(CancellationToken cancellationToken);
	Task<Site> GetSiteById(Guid id, CancellationToken cancellationToken);
	Task<Guid> CreateSite(Site site, CancellationToken cancellationToken);
	Task<Guid> UpdateSite(Site site, CancellationToken cancellationToken);
	Task<Guid> DeleteSite(Guid id, CancellationToken cancellationToken);
}
