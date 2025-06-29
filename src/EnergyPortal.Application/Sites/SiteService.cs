using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public class SiteService : ISiteService
{
	private readonly ISiteRepository _siteRepository;

	public SiteService(ISiteRepository siteRepository)
	{
		_siteRepository = siteRepository;
	}

	public async Task<List<Site>> GetSites()
	{
		return await _siteRepository.GetSites();
	}

	public async Task<Site> AddSite(Site site)
	{
		return await _siteRepository.AddSite(site);
	}
}
