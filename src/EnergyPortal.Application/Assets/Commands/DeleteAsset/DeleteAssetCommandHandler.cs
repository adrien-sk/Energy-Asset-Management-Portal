using EnergyPortal.Application.Common.Commands;
using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Common;

namespace EnergyPortal.Application.Assets.Commands.DeleteAsset;

internal sealed class DeleteAssetCommandHandler : ICommandHandler<DeleteAssetCommand>
{
	private readonly IAssetsRepository _assetsRepository;

	public DeleteAssetCommandHandler(IAssetsRepository assetsRepository)
	{
		_assetsRepository = assetsRepository;
	}

	public async Task<Result> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
	{
		var id = await _assetsRepository.DeleteAsset(request.Id, cancellationToken);

		if (id == Guid.Empty)
		{
			return Result.Failure($"Error while deleting the asset in the database : {request.Id}");
		}

		return Result.Success();
	}
}
