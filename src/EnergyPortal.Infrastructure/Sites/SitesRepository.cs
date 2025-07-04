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
		var sites = await _context.Sites.ToListAsync(cancellationToken);
		return sites;
	}

	public async Task<Site> GetSite(Guid id)
	{
		var sites = await _context.Sites.FindAsync(id);
		return sites;
	}

	public async Task<Guid> CreateSite(Site site, CancellationToken cancellationToken)
	{
		await _context.Sites.AddAsync(site, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);

		return site.Id;
	}

	public async Task<Guid> UpdateSite(Site updatedSite)
	{
		if (updatedSite is not null)
		{
			_context.Sites.Update(updatedSite);
			await _context.SaveChangesAsync();
		}

		return updatedSite.Id;
	}

	public async Task<Guid> DeleteSite(Guid id)
	{
		var site = await _context.Sites.FindAsync(id);
		if (site is not null)
		{
			_context.Sites.Remove(site);
			await _context.SaveChangesAsync();
		}
		return id;
	}
}
