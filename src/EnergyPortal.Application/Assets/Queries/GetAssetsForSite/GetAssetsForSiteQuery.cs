using EnergyPortal.Application.Common.Queries;
using EnergyPortal.Domain.Assets;

namespace EnergyPortal.Application.Assets.Queries.GetAssetsForSite;

public sealed record GetAssetsForSiteQuery(
	Guid id) : IQuery<IEnumerable<Asset>>;