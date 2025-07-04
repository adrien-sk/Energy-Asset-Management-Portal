using EnergyPortal.Domain.Sites;
using EnergyPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyPortal.Infrastructure.Sites;

public class SitesRepository : ISitesRepository
{
	private readonly ApplicationDbContext _context;

	public SitesRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Site>> GetSites(CancellationToken cancellationToken)
	{
		return await _context.Sites.ToListAsync(cancellationToken);
	}

	public async Task<Site> GetSiteById(Guid id, CancellationToken cancellationToken)
	{
		return await _context.Sites.FindAsync([id], cancellationToken);
	}

	public async Task<Guid> CreateSite(Site site, CancellationToken cancellationToken)
	{
		await _context.Sites.AddAsync(site, cancellationToken);
		return await _context.SaveChangesAsync(cancellationToken) >= 1 ? site.Id : Guid.Empty;
	}

	public async Task<Guid> UpdateSite(Site updatedSite, CancellationToken cancellationToken)
	{
		if (updatedSite is null)
		{
			return Guid.Empty;
		}

		_context.Sites.Update(updatedSite);
		return await _context.SaveChangesAsync(cancellationToken) >= 1 ? updatedSite.Id : Guid.Empty;
	}

	public async Task<Guid> DeleteSite(Guid id, CancellationToken cancellationToken)
	{
		var site = await _context.Sites.FindAsync([id], cancellationToken);
		var guid = Guid.Empty;

		if (site is not null)
		{
			_context.Sites.Remove(site);
			guid = await _context.SaveChangesAsync(cancellationToken) >= 1 ? site.Id : Guid.Empty;
		}
		return guid;
	}
}
