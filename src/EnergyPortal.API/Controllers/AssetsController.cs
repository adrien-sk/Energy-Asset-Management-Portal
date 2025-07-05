using EnergyPortal.Application.Assets.Queries.GetAssetsForSite;
using EnergyPortal.Domain.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

public sealed class AssetsController : BaseApiController
{
	public AssetsController(ISender sender) : base(sender)
	{
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<IEnumerable<Asset>>> GetAssetsBySite(Guid id, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(new GetAssetsForSiteQuery(id), cancellationToken);
		return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
	}

	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Asset>> GetAsset(Guid id)
	{
		return Ok();
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> CreateAsset(Asset asset)
	{
		return Ok();
	}

	[HttpPut("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> UpdateAsset(Asset asset)
	{
		return NoContent();
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> DeleteAsset(Guid id)
	{
		return NoContent();
	}
}
