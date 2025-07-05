using EnergyPortal.Domain.Assets;
using EnergyPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyPortal.Infrastructure.Assets;


public class AssetsRepository : IAssetsRepository
{
	private readonly ApplicationDbContext _context;

	public AssetsRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Asset>> GetAssetsBySite(Guid id, CancellationToken cancellationToken)
	{
		return await _context.Assets.Where(a => a.SiteId == id).ToListAsync(cancellationToken);
	}

	public async Task<Asset> GetAssetById(Guid id, CancellationToken cancellationToken)
	{
		return await _context.Assets.FindAsync([id], cancellationToken);
	}

	public async Task<Guid> CreateAsset(Asset asset, CancellationToken cancellationToken)
	{
		await _context.Assets.AddAsync(asset, cancellationToken);
		return await _context.SaveChangesAsync(cancellationToken) >= 1 ? asset.Id : Guid.Empty;
	}

	public async Task<Guid> UpdateAsset(Asset updatedAsset, CancellationToken cancellationToken)
	{
		if (updatedAsset is null)
		{
			return Guid.Empty;
		}

		_context.Assets.Update(updatedAsset);
		return await _context.SaveChangesAsync(cancellationToken) >= 1 ? updatedAsset.Id : Guid.Empty;
	}

	public async Task<Guid> DeleteAsset(Guid id, CancellationToken cancellationToken)
	{
		var asset = await _context.Assets.FindAsync([id], cancellationToken);
		var guid = Guid.Empty;

		if (asset is not null)
		{
			_context.Assets.Remove(asset);
			guid = await _context.SaveChangesAsync(cancellationToken) >= 1 ? asset.Id : Guid.Empty;
		}
		return guid;
	}
}
