using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites;

public interface ISiteService
{
	List<Site> GetSites();
}
