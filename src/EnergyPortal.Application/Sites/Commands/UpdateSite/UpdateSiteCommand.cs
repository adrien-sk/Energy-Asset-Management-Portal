using EnergyPortal.Application.Common.Commands;

namespace EnergyPortal.Application.Sites.Commands.UpdateSite;

public sealed record UpdateSiteCommand(
	Guid Id,
	string Name,
	decimal Latitude,
	decimal Longitude,
	string Address,
	string City,
	string Region) : ICommand;