using EnergyPortal.Application.Common.Commands;

namespace EnergyPortal.Application.Assets.Commands.CreateAsset;

public sealed record CreateAssetCommand(
	string Name,
	decimal Latitude,
	decimal Longitude,
	string Address,
	string City,
	string Region) : ICommand<Guid>;