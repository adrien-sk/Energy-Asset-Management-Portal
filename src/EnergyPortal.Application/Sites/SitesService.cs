using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public class SitesService : ISitesService
{
	private readonly ISitesRepository _sitesRepository;

	public SitesService(ISitesRepository sitesRepository)
	{
		_sitesRepository = sitesRepository;
	}

	public async Task<IEnumerable<Site>> GetSites()
	{
		return await _sitesRepository.GetSites();
	}

	public async Task<Site> GetSite(Guid id)
	{
		return await _sitesRepository.GetSite(id);
	}

	public async Task<Guid> CreateSite(Site site)
	{
		return await _sitesRepository.CreateSite(site);
	}

	public async Task<Guid> UpdateSite(Site site)
	{
		return await _sitesRepository.UpdateSite(site);
	}

	public async Task<Guid> DeleteSite(Guid id)
	{
		return await _sitesRepository.DeleteSite(id);
	}
}
