using EnergyPortal.Domain.Common.Enums;

namespace EnergyPortal.Domain.Common.ValueObjects;

public record EnergyReading
{
	public decimal Value { get; }
	public EnergyUnit Unit { get; }
	public DateTime Timestamp { get; }
}
