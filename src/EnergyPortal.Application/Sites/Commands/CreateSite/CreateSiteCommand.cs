using EnergyPortal.Application.Common.Commands;

namespace EnergyPortal.Application.Sites.Commands.CreateSite;

public sealed record CreateSiteCommand(
	string Name,
	decimal Latitude,
	decimal Longitude,
	string Address,
	string City,
	string Region) : ICommand<Guid>;