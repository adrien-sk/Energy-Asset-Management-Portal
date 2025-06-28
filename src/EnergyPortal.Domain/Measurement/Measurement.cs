using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Measurement;

public class Measurement : BaseEntity
{
	public Guid AssetId { get; private set; }
	public EnergyReading? EnergyProduced { get; private set; }
	public EnergyReading? EnergyConsumed { get; private set; }
	public DateTime Timestamp { get; private set; }

	// Private constructor for EF Core
	private Measurement() { }
}
