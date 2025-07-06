using EnergyPortal.Application.Common.Commands;
using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Application.Assets.Commands.UpdateAsset;

public sealed record UpdateAssetCommand(
	Guid Id,

	decimal TiltAngle,
	decimal Azimuth,

	decimal CurrentCharge,
	decimal ChargeCapacity,
	decimal MaxChargeRate,
	decimal MaxDischargeRate,
	int CycleCount,
	decimal StateOfHealth,
	decimal Temperature,

	decimal DcInput,
	decimal AcOutput,
	decimal DcVoltage,
	decimal AcVoltage,
	decimal Frequency,

	Guid SiteId,
	AssetStatus Status,
	AssetType Type,
	Capacity Capacity,
	DateTime InstallationDate,
	string Manufacturer,
	string Model) : ICommand;