using EnergyPortal.Domain.Common;
using MediatR;

namespace EnergyPortal.Application.Common.Queries;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
	where TQuery : IQuery<TResponse>
{
}
