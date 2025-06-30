using EnergyPortal.Domain.Common.Enums;
using EnergyPortal.Domain.Sites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyPortal.Infrastructure.Sites;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
	public void Configure(EntityTypeBuilder<Site> builder)
	{
		builder.OwnsOne(s => s.TotalCapacity, capacity =>
		{
			capacity.Property(c => c.Output)
				.HasColumnName("TotalCapacity_Output")
				.HasPrecision(18, 2)
				.IsRequired();

			capacity.Property(c => c.Unit)
				.HasColumnName("TotalCapacity_Unit")
				.HasMaxLength(10)
				.IsRequired()
				.HasConversion(
					unit => unit.ToString(),
					value => Enum.Parse<CapacityUnit>(value));
		});

		builder.OwnsOne(s => s.Location, location =>
		{
			location.Property(l => l.Latitude)
				.HasColumnName("Location_Latitude")
				.HasPrecision(10, 7);

			location.Property(l => l.Longitude)
				.HasColumnName("Location_Longitude")
				.HasPrecision(10, 7);

			location.Property(l => l.Address)
				.HasColumnName("Location_Address")
				.HasMaxLength(500);

			location.Property(l => l.City)
				.HasColumnName("Location_City")
				.HasMaxLength(500);

			location.Property(l => l.Region)
				.HasColumnName("Location_Region")
				.HasMaxLength(500);
		});
	}
}