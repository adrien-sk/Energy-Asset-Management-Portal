using EnergyPortal.Domain.Common.Enums;

namespace EnergyPortal.Domain.Common.ValueObjects;

public record Capacity
{
	public decimal Output { get; }
	public CapacityUnit Unit { get; }
}
