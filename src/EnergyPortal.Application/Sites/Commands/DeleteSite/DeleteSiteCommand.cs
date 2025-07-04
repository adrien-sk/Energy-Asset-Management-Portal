using EnergyPortal.Application.Common.Commands;

namespace EnergyPortal.Application.Sites.Commands.DeleteSite;

public sealed record DeleteSiteCommand(
	Guid id) : ICommand;