namespace EnergyPortal.Domain.Assets;

public interface IAssetsRepository
{
	Task<IEnumerable<Asset>> GetAssetsBySite(Guid id, CancellationToken cancellationToken);
	Task<Asset> GetAssetById(Guid id, CancellationToken cancellationToken);
	Task<Guid> CreateAsset(Asset asset, CancellationToken cancellationToken);
	Task<Guid> UpdateAsset(Asset asset, CancellationToken cancellationToken);
	Task<Guid> DeleteAsset(Guid id, CancellationToken cancellationToken);
}