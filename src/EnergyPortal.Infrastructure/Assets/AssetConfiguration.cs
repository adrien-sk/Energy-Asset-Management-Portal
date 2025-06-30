using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyPortal.Infrastructure.Assets;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
	public void Configure(EntityTypeBuilder<Asset> builder)
	{
		builder.HasDiscriminator<string>("AssetType")
			.HasValue<SolarPanel>("SolarPanel")
			.HasValue<Battery>("Battery")
			.HasValue<Inverter>("Inverter");

		// Configure Capacity as owned entity
		builder.OwnsOne(a => a.Capacity, capacity =>
		{
			capacity.Property(c => c.Output)
				.HasColumnName("Capacity_Output")
				.HasPrecision(18, 2)
				.IsRequired();

			capacity.Property(c => c.Unit)
				.HasColumnName("Capacity_Unit")
				.HasMaxLength(10)
				.IsRequired()
				.HasConversion(
					unit => unit.ToString(),
					value => Enum.Parse<CapacityUnit>(value));
		});
	}
}