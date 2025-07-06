using EnergyPortal.Application.Common.Commands;

namespace EnergyPortal.Application.Assets.Commands.DeleteAsset;

public sealed record DeleteAssetCommand(
	Guid Id) : ICommand;