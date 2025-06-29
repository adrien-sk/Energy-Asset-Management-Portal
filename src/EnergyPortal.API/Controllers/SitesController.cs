using EnergyPortal.Application.Sites;
using EnergyPortal.Domain.Sites;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SitesController : ControllerBase
{
	private readonly ISiteService _siteService;

	public SitesController(ISiteService siteService)
	{
		_siteService = siteService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Site>>> GetSites()
	{
		var sites = await _siteService.GetSites();
		return Ok(sites);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Site>> GetSite(Guid id)
	{
		var site = await _siteService.GetSite(id);
		return Ok(site);
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> CreateSite(Site site)
	{
		var siteId = await _siteService.CreateSite(site);
		return Ok(siteId);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<Guid>> UpdateSite(Guid id, Site site)
	{
		var updatedId = await _siteService.UpdateSite(id, site);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<Guid>> DeleteSite(Guid id)
	{
		var deletedId = await _siteService.DeleteSite(id);
		return NoContent();
	}

}
