using EnergyPortal.Application.Sites;
using EnergyPortal.Application.Sites.Commands.CreateSite;
using EnergyPortal.Application.Sites.Queries.GetSite;
using EnergyPortal.Domain.Sites;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

public sealed class SitesController : BaseApiController
{
	private readonly ISitesService _sitesService;

	public SitesController(ISender sender, ISitesService sitesService) : base(sender)
	{
		_sitesService = sitesService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Site>>> GetSites()
	{
		var result = await Sender.Send(new GetSitesQuery());
		return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
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
		var result = await Sender.Send(site);

		return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
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