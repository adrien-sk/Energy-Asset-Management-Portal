using EnergyPortal.Domain.Sites;
using EnergyPortal.Infrastructure.Data;

namespace EnergyPortal.Infrastructure.Sites;

public class SiteRepository : ISiteRepository
{
	private readonly ApplicationDbContext _context;

	public SiteRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public List<Site> GetSites()
	{
		var sites = new List<Site>
		{
			new("Test", new Domain.Common.ValueObjects.Location(){ }, new Domain.Common.ValueObjects.Capacity(){ }),
			new("Test 2", new Domain.Common.ValueObjects.Location(){ }, new Domain.Common.ValueObjects.Capacity(){ })
		};

		return sites;
	}
}
