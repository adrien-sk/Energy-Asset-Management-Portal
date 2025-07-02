using EnergyPortal.Domain.Common;
using MediatR;

namespace EnergyPortal.Application.Common.Commands;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
	where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
	where TCommand : ICommand<TResponse>
{
}