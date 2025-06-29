using EnergyPortal.Application.Sites;
using EnergyPortal.Domain.Sites;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SiteController : ControllerBase
{
	private readonly ISiteService _siteService;

	public SiteController(ISiteService siteService)
	{
		_siteService = siteService;
	}

	[HttpGet]
	public async Task<ActionResult<List<Site>>> GetSites()
	{
		var sites = await _siteService.GetSites();
		return Ok(sites);
	}

	[HttpPost]
	public async Task<ActionResult<Site>> AddSite(Site site)
	{
		var sites = await _siteService.AddSite(site);
		return Ok(sites);
	}
}
