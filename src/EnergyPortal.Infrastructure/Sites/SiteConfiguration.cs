using EnergyPortal.Domain.Sites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyPortal.Infrastructure.Sites;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
	public void Configure(EntityTypeBuilder<Site> builder)
	{
		//builder.OwnsOne(s => s.TotalCapacity, capacity =>
		//{
		//	capacity.Property(c => c.Output)
		//		.HasColumnName("TotalCapacity_Output")
		//		.HasPrecision(18, 2)
		//		.IsRequired();

		//	capacity.Property(c => c.Unit)
		//		.HasColumnName("TotalCapacity_Unit")
		//		.HasMaxLength(10)
		//		.IsRequired()
		//		.HasConversion(
		//			unit => unit.ToString(),
		//			value => Enum.Parse<CapacityUnit>(value));
		//});

		builder.OwnsOne(s => s.Location, location =>
		{
			location.Property(l => l.Latitude)
				.HasColumnName("Latitude")
				.HasPrecision(10, 7);

			location.Property(l => l.Longitude)
				.HasColumnName("Longitude")
				.HasPrecision(10, 7);

			location.Property(l => l.Address)
				.HasColumnName("Address")
				.HasMaxLength(500);

			location.Property(l => l.City)
				.HasColumnName("City")
				.HasMaxLength(500);

			location.Property(l => l.Region)
				.HasColumnName("Region")
				.HasMaxLength(500);
		});
	}
}