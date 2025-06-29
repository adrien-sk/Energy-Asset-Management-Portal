using EnergyPortal.Domain.Sites;
using EnergyPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyPortal.Infrastructure.Sites;

public class SiteRepository : ISiteRepository
{
	private readonly ApplicationDbContext _context;

	public SiteRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Site>> GetSites()
	{
		var sites = await _context.Sites.ToListAsync();
		return sites;
	}

	public async Task<Site> GetSite(Guid id)
	{
		var sites = await _context.Sites.FindAsync(id);
		return sites;
	}

	public async Task<Guid> CreateSite(Site site)
	{
		await _context.Sites.AddAsync(site);
		await _context.SaveChangesAsync();

		return site.Id;
	}

	public async Task<Guid> UpdateSite(Guid id, Site site)
	{
		await _context.Sites.
			Where(model => model.Id == id)
			.ExecuteUpdateAsync(setters => setters
				.SetProperty(s => s.Name, site.Name)
				.SetProperty(s => s.InstallationDate, site.InstallationDate)
			);
		return id;
	}

	public async Task<Guid> DeleteSite(Guid id)
	{
		var site = await _context.Sites.FindAsync(id);
		_context.Sites.Remove(site);
		await _context.SaveChangesAsync();
		return id;
	}
}
