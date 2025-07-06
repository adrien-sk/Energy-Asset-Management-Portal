using EnergyPortal.Application.Common.Queries;
using EnergyPortal.Domain.Assets;

namespace EnergyPortal.Application.Sites.Queries.GetAssetsForSite;

public sealed record GetAssetsForSiteQuery(
	Guid Id) : IQuery<IEnumerable<Asset>>;