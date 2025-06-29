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
	public ActionResult<List<Site>> Get()
	{
		var sites = _siteService.GetSites();
		return Ok(sites);
	}
}
