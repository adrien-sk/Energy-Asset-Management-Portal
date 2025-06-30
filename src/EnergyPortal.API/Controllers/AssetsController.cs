using EnergyPortal.Application.Assets;
using EnergyPortal.Domain.Assets;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
	private readonly IAssetsService _assetsService;

	public AssetsController(IAssetsService assetsService)
	{
		_assetsService = assetsService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
	{
		var Assets = await _assetsService.GetAssets();
		return Ok(Assets);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Asset>> GetAsset(Guid id)
	{
		var Asset = await _assetsService.GetAsset(id);
		return Ok(Asset);
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> CreateAsset(Asset Asset)
	{
		var AssetId = await _assetsService.CreateAsset(Asset);
		return Ok(AssetId);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<Guid>> UpdateAsset(Guid id, Asset Asset)
	{
		var updatedId = await _assetsService.UpdateAsset(id, Asset);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<Guid>> DeleteAsset(Guid id)
	{
		var deletedId = await _assetsService.DeleteAsset(id);
		return NoContent();
	}
}
