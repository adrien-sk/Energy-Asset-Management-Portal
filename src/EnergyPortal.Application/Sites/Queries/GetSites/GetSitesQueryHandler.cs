using EnergyPortal.Application.Common.Queries;
using EnergyPortal.Application.Sites.Queries.GetSite;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Queries.GetSites;

internal sealed class GetSitesQueryHandler : IQueryHandler<GetSitesQuery, IEnumerable<Site>>
{
	private readonly ISitesRepository _sitesRepository;

	public GetSitesQueryHandler(ISitesRepository sitesRepository)
	{
		_sitesRepository = sitesRepository;
	}

	public async Task<Result<IEnumerable<Site>>> Handle(GetSitesQuery request, CancellationToken cancellationToken)
	{
		var sites = await _sitesRepository.GetSites(cancellationToken);

		if (sites == null)
		{
			return Result.Failure<IEnumerable<Site>>("Cannot retrieve Sites from database");
		}

		return Result.Success(sites);
	}
}
