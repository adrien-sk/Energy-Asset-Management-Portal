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

	public async Task<List<Site>> GetSites()
	{
		var sites = await _context.Sites.ToListAsync();

		return sites;
	}

	public async Task<Site> AddSite(Site site)
	{
		await _context.Sites.AddAsync(site);
		await _context.SaveChangesAsync();

		return site;
	}
}
