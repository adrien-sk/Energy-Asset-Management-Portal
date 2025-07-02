using EnergyPortal.Domain.Common;
using MediatR;

namespace EnergyPortal.Application.Common.Commands;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
