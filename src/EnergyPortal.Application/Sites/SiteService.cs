using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public class SiteService : ISiteService
{
	private readonly ISiteRepository _siteRepository;

	public SiteService(ISiteRepository siteRepository)
	{
		_siteRepository = siteRepository;
	}

	public async Task<IEnumerable<Site>> GetSites()
	{
		return await _siteRepository.GetSites();
	}

	public async Task<Site> GetSite(Guid id)
	{
		return await _siteRepository.GetSite(id);
	}

	public async Task<Guid> CreateSite(Site site)
	{
		return await _siteRepository.CreateSite(site);
	}

	public async Task<Guid> UpdateSite(Guid id, Site site)
	{
		return await _siteRepository.UpdateSite(id, site);
	}

	public async Task<Guid> DeleteSite(Guid id)
	{
		return await _siteRepository.DeleteSite(id);
	}
}
