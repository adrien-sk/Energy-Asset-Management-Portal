using EnergyPortal.Application.Common.Queries;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Queries.GetSiteById;

public sealed record GetSiteByIdQuery(
	Guid id) : IQuery<Site>;