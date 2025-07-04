namespace EnergyPortal.Domain.Sites;

public interface ISitesRepository
{
	Task<IEnumerable<Site>> GetSites(CancellationToken cancellationToken);
	Task<Site> GetSite(Guid id);
	Task<Guid> CreateSite(Site site, CancellationToken cancellationToken);
	Task<Guid> UpdateSite(Site site);
	Task<Guid> DeleteSite(Guid id);
}
