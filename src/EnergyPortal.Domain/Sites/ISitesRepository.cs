namespace EnergyPortal.Domain.Sites;

public interface ISitesRepository
{
	Task<IEnumerable<Site>> GetSites();
	Task<Site> GetSite(Guid id);
	Task<Guid> CreateSite(Site site);
	Task<Guid> UpdateSite(Site site);
	Task<Guid> DeleteSite(Guid id);
}
