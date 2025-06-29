using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public class SiteService : ISiteService
{
	private readonly ISiteRepository _siteRepository;

	public SiteService(ISiteRepository siteRepository)
	{
		_siteRepository = siteRepository;
	}

	public List<Site> GetSites()
	{
		return _siteRepository.GetSites();
	}
}
