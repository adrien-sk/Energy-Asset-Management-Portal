using EnergyPortal.Application.Common.Queries;
using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Queries.GetAssetsForSite;

internal sealed class GetAssetsForSiteQueryHandler : IQueryHandler<GetAssetsForSiteQuery, IEnumerable<Asset>>
{
	private readonly ISitesRepository _sitesRepository;
	private readonly IAssetsRepository _assetsRepository;

	public GetAssetsForSiteQueryHandler(ISitesRepository sitesRepository, IAssetsRepository assetsRepository)
	{
		_sitesRepository = sitesRepository;
		_assetsRepository = assetsRepository;
	}
	public async Task<Result<IEnumerable<Asset>>> Handle(GetAssetsForSiteQuery request, CancellationToken cancellationToken)
	{
		var site = await _sitesRepository.GetSiteById(request.Id, cancellationToken);

		if (site == null) return Result.Failure<IEnumerable<Asset>>("Site not found");

		var assets = await _assetsRepository.GetAssetsBySite(site.Id, cancellationToken);

		return Result.Success(assets);
	}
}