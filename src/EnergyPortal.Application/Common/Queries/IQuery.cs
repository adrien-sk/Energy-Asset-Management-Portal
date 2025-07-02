using EnergyPortal.Domain.Common;
using MediatR;

namespace EnergyPortal.Application.Common.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
