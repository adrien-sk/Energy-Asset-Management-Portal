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
		var assets = await _assetsService.GetAssets();
		return Ok(assets);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Asset>> GetAsset(Guid id)
	{
		var asset = await _assetsService.GetAsset(id);
		return Ok(asset);
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> CreateAsset(Asset asset)
	{
		var assetId = await _assetsService.CreateAsset(asset);
		return Ok(assetId);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<Guid>> UpdateAsset(Asset asset)
	{
		var updatedId = await _assetsService.UpdateAsset(asset);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<Guid>> DeleteAsset(Guid id)
	{
		var deletedId = await _assetsService.DeleteAsset(id);
		return NoContent();
	}
}
