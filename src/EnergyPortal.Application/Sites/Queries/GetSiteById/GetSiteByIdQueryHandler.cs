using EnergyPortal.Application.Common.Queries;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Queries.GetSiteById;

internal sealed class GetSiteByIdQueryHandler : IQueryHandler<GetSiteByIdQuery, Site>
{
	private readonly ISitesRepository _sitesRepository;

	public GetSiteByIdQueryHandler(ISitesRepository sitesRepository)
	{
		_sitesRepository = sitesRepository;
	}
	public async Task<Result<Site>> Handle(GetSiteByIdQuery request, CancellationToken cancellationToken)
	{
		var site = await _sitesRepository.GetSiteById(request.Id, cancellationToken);

		if (site == null)
		{
			return Result.Failure<Site>($"Cannot retrieve Site from database for id : {request.Id}");
		}

		return Result.Success(site);
	}
}