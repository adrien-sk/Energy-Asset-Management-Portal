using EnergyPortal.Application.Common.Queries;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Queries.GetSite;

public sealed record GetSitesQuery() : IQuery<IEnumerable<Site>>;