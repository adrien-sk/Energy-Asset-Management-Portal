using EnergyPortal.Application.Sites;
using EnergyPortal.Application.Sites.Commands.CreateSite;
using EnergyPortal.Domain.Sites;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SitesController : ControllerBase
{
	private readonly ISitesService _sitesService;

	public SitesController(ISitesService sitesService)
	{
		_sitesService = sitesService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Site>>> GetSites()
	{
		var sites = await _sitesService.GetSites();
		return Ok(sites);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Site>> GetSite(Guid id)
	{
		var site = await _sitesService.GetSite(id);
		return Ok(site);
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> CreateSite(CreateSiteCommand site)
	{
		var siteId = await _sitesService.CreateSite(site);
		return Ok(siteId);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<Guid>> UpdateSite(Guid id, CreateSiteCommand site)
	{
		var updatedId = await _sitesService.UpdateSite(id, site);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<Guid>> DeleteSite(Guid id)
	{
		var deletedId = await _sitesService.DeleteSite(id);
		return NoContent();
	}
}