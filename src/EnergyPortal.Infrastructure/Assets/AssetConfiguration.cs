using EnergyPortal.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyPortal.Infrastructure.Assets;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
	public void Configure(EntityTypeBuilder<Asset> builder)
	{
		builder.HasKey(a => a.Id);

		builder.HasDiscriminator<string>("AssetType")
			.HasValue<SolarPanel>("SolarPanel")
			.HasValue<Battery>("Battery")
			.HasValue<Inverter>("Inverter");

		builder.Property(a => a.Id)
			.IsRequired();

		builder.Property(a => a.CreatedAt)
			.IsRequired();

		builder.Property(a => a.SiteId)
			.IsRequired();

		builder.Property(a => a.Type)
			.HasConversion<string>()
			.IsRequired();

		builder.ComplexProperty(a => a.Capacity, capacityBuilder =>
		{
			capacityBuilder.Property(c => c.Output)
				.HasColumnName("CapacityValue")
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			capacityBuilder.Property(c => c.Unit)
				.HasColumnName("CapacityUnit")
				.HasMaxLength(10)
				.IsRequired();
		});

		builder.HasIndex(a => a.SiteId)
			.HasDatabaseName("IX_Assets_SiteId");

		builder.HasIndex(a => a.Status)
			.HasDatabaseName("IX_Assets_Status");

		builder.HasIndex(a => a.Type)
			.HasDatabaseName("IX_Assets_Type");
	}
}