using EnergyPortal.Application.Common.Commands;
using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Assets.Commands.CreateAsset;

internal sealed class CreateAssetCommandHandler : ICommandHandler<CreateAssetCommand, Guid>
{
	private readonly ISitesRepository _sitesRepository;
	private readonly IAssetsRepository _assetsRepository;

	public CreateAssetCommandHandler(ISitesRepository sitesRepository, IAssetsRepository assetsRepository)
	{
		_sitesRepository = sitesRepository;
		_assetsRepository = assetsRepository;
	}

	public async Task<Result<Guid>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
	{
		var site = await _sitesRepository.GetSiteById(request.SiteId, cancellationToken);
		if (site == null) return Result.Failure<Guid>("Site not found");

		Asset newAsset = null;

		switch (request.Type)
		{
			case AssetType.SolarPanel:
				newAsset = await AssetFactory.CreateSolarPanel(request.TiltAngle, request.Azimuth, request.SiteId, request.Status, request.Type, request.Capacity, request.InstallationDate, request.Manufacturer, request.Model, "Tester");
				break;
			case AssetType.Battery:
				newAsset = await AssetFactory.CreateBattery(request.CurrentCharge, request.ChargeCapacity, request.MaxChargeRate, request.MaxDischargeRate, request.CycleCount, request.StateOfHealth, request.Temperature, request.SiteId, request.Status, request.Type, request.Capacity, request.InstallationDate, request.Manufacturer, request.Model, "Tester");
				break;
			case AssetType.Inverter:
				newAsset = await AssetFactory.CreateInverter(request.DcInput, request.AcOutput, request.DcVoltage, request.AcVoltage, request.Frequency, request.Temperature, request.SiteId, request.Status, request.Type, request.Capacity, request.InstallationDate, request.Manufacturer, request.Model, "Tester");
				break;
			default:
				break;
		}

		if (newAsset is null)
		{
			return Result.Failure<Guid>("Error while creating the asset");
		}

		var id = await _assetsRepository.CreateAsset(newAsset, cancellationToken);

		if (id == Guid.Empty)
		{
			return Result.Failure<Guid>("Error while creating the asset in the database");
		}

		return Result.Success(id);
	}
}
