using EnergyPortal.Application.Common.Commands;
using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Assets.Commands.UpdateAsset;

internal sealed class UpdateAssetCommandHandler : ICommandHandler<UpdateAssetCommand>
{
	private readonly ISitesRepository _sitesRepository;
	private readonly IAssetsRepository _assetsRepository;

	public UpdateAssetCommandHandler(ISitesRepository sitesRepository, IAssetsRepository assetsRepository)
	{
		_sitesRepository = sitesRepository;
		_assetsRepository = assetsRepository;

	}

	public async Task<Result> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
	{
		var asset = await _assetsRepository.GetAssetById(request.Id, cancellationToken);

		if (asset == null)
		{
			return Result.Failure<Asset>($"Cannot retrieve Asset from database for id : {request.Id}");
		}

		switch (asset)
		{
			case SolarPanel solarPanel:
				solarPanel.Update(request.TiltAngle, request.Azimuth, request.SiteId, request.Status, request.Type, request.Capacity, request.InstallationDate, request.Manufacturer, request.Model, "Tester");
				break;
			case Battery battery:
				battery.Update(request.CurrentCharge, request.ChargeCapacity, request.MaxChargeRate, request.MaxDischargeRate, request.CycleCount, request.StateOfHealth, request.Temperature, request.SiteId, request.Status, request.Type, request.Capacity, request.InstallationDate, request.Manufacturer, request.Model, "Tester");
				break;
			case Inverter inverter:
				inverter.Update(request.DcInput, request.AcOutput, request.DcVoltage, request.AcVoltage, request.Frequency, request.Temperature, request.SiteId, request.Status, request.Type, request.Capacity, request.InstallationDate, request.Manufacturer, request.Model, "Tester");
				break;
			default:
				break;
		}

		var id = await _assetsRepository.UpdateAsset(asset, cancellationToken);

		if (id == Guid.Empty)
		{
			return Result.Failure($"Error while updating the asset in the database : {request.Id}");
		}

		return Result.Success(id);
	}
}
