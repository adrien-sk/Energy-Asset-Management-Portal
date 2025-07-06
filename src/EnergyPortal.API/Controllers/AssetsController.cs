using EnergyPortal.Application.Assets.Commands.CreateAsset;
using EnergyPortal.Application.Assets.Commands.DeleteAsset;
using EnergyPortal.Application.Assets.Commands.UpdateAsset;
using EnergyPortal.Domain.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

public sealed class AssetsController : BaseApiController
{
	public AssetsController(ISender sender) : base(sender)
	{
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
	public async Task<ActionResult<Guid>> CreateAsset(CreateAssetCommand asset, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(asset, cancellationToken);
		return result.IsSuccess ? CreatedAtAction(nameof(GetAsset), new { id = result.Value }, result.Value) : BadRequest(result.Error);
	}

	[HttpPut("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> UpdateAsset(Guid id, UpdateAssetCommand asset, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(asset, cancellationToken);
		return result.IsSuccess ? NoContent() : BadRequest(result.Error);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> DeleteAsset(Guid id, CancellationToken cancellationToken)
	{
		var result = await Sender.Send(new DeleteAssetCommand(id), cancellationToken);
		return result.IsSuccess ? NoContent() : BadRequest(result.Error);
	}
}
