using EnergyPortal.Application.Sites.Commands.CreateSite;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public class SitesService : ISitesService
{
	private readonly ISitesRepository _sitesRepository;
	private readonly SiteFactory _siteFactory;

	public SitesService(ISitesRepository sitesRepository, SiteFactory siteFactory)
	{
		_sitesRepository = sitesRepository;
		_siteFactory = siteFactory;
	}

	public async Task<Site> GetSite(Guid id)
	{
		return await _sitesRepository.GetSite(id);
	}

	public async Task<Guid> UpdateSite(Guid id, CreateSiteCommand site)
	{
		var dbSite = await _sitesRepository.GetSite(id);

		var location = new Location(site.Latitude,
			site.Longitude,
			site.Address,
			site.City,
			site.Region);

		dbSite.Update(site.Name, location, "Tester");

		return await _sitesRepository.UpdateSite(dbSite);
	}

	public async Task<Guid> DeleteSite(Guid id)
	{
		return await _sitesRepository.DeleteSite(id);
	}
}
