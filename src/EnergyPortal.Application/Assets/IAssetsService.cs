﻿using EnergyPortal.Domain.Assets;

namespace EnergyPortal.Application.Assets;
public interface IAssetsService
{
	Task<IEnumerable<Asset>> GetAssets();
	Task<Asset> GetAsset(Guid id);
	Task<Guid> CreateAsset(Asset asset);
	Task<Guid> UpdateAsset(Asset asset);
	Task<Guid> DeleteAsset(Guid id);
}
