using EnergyPortal.Domain.Common.Enums;

namespace EnergyPortal.Domain.Common.ValueObjects;

public record Capacity
{
	public decimal Output { get; } = decimal.Zero;
	public CapacityUnit Unit { get; } = CapacityUnit.Watts;
}
