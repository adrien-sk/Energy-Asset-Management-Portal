using EnergyPortal.Domain.Assets;

namespace EnergyPortal.Application.Assets;

public class AssetsService : IAssetsService
{
	private readonly IAssetsRepository _assetsRepository;

	public AssetsService(IAssetsRepository assetsRepository)
	{
		_assetsRepository = assetsRepository;
	}

	public async Task<IEnumerable<Asset>> GetAssets()
	{
		return await _assetsRepository.GetAssets();
	}

	public async Task<Asset> GetAsset(Guid id)
	{
		return await _assetsRepository.GetAsset(id);
	}

	public async Task<Guid> CreateAsset(Asset asset)
	{
		return await _assetsRepository.CreateAsset(asset);
	}

	public async Task<Guid> UpdateAsset(Asset asset)
	{
		return await _assetsRepository.UpdateAsset(asset);
	}

	public async Task<Guid> DeleteAsset(Guid id)
	{
		return await _assetsRepository.DeleteAsset(id);
	}
}