using EnergyPortal.Application.Sites.Commands.CreateSite;
using EnergyPortal.Application.Sites.Commands.DeleteSite;
using EnergyPortal.Application.Sites.Commands.UpdateSite;
using EnergyPortal.Application.Sites.Queries.GetAssetsForSite;
using EnergyPortal.Application.Sites.Queries.GetSite;
using EnergyPortal.Application.Sites.Queries.GetSiteById;
using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Sites;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

public sealed class SitesController : BaseApiController
{
	public SitesController(ISender sender) : base(sender)
	{
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<IEnumerable<Site>>> GetSites(CancellationToken cancellationToken)
	{
		var result = await Sender.Send(new GetSitesQuery(), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
	}

	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Site>> GetSite(Guid id, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(new GetSiteByIdQuery(id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
	}

	[HttpGet("{id}/assets")]
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<IEnumerable<Asset>>> GetAssetsBySite(Guid id, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(new GetAssetsForSiteQuery(id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> CreateSite(CreateSiteCommand site, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(site, cancellationToken);
		return result.IsSuccess ? CreatedAtAction(nameof(GetSite), new { id = result.Value }, result.Value) : BadRequest(result.Error);
	}

	[HttpPut("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> UpdateSite(Guid id, UpdateSiteCommand site, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(site, cancellationToken);
		return result.IsSuccess ? NoContent() : BadRequest(result.Error);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> DeleteSite(Guid id, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(new DeleteSiteCommand(id), cancellationToken);
		return result.IsSuccess ? NoContent() : BadRequest(result.Error);
	}
}