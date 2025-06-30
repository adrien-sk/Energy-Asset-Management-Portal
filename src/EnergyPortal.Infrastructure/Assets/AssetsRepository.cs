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

	public async Task<IEnumerable<Asset>> GetAssets()
	{
		var assets = await _context.Assets.ToListAsync();
		return assets;
	}

	public async Task<Asset> GetAsset(Guid id)
	{
		var assets = await _context.Assets.FindAsync(id);
		return assets;
	}

	public async Task<Guid> CreateAsset(Asset asset)
	{
		await _context.Assets.AddAsync(asset);
		await _context.SaveChangesAsync();

		return asset.Id;
	}

	public async Task<Guid> UpdateAsset(Asset updatedAsset)
	{
		//var asset = await _context.Assets.FindAsync(updatedAsset.Id);

		//if (asset is not null)
		//{
		//	asset.Update(???);

		//	await _context.SaveChangesAsync();
		//}

		return updatedAsset.Id;
	}

	public async Task<Guid> DeleteAsset(Guid id)
	{
		var asset = await _context.Assets.FindAsync(id);

		if (asset is not null)
		{
			_context.Assets.Remove(asset);
			await _context.SaveChangesAsync();
		}

		return id;
	}
}
