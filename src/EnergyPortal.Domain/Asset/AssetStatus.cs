namespace EnergyPortal.Domain.Asset;

public enum AssetStatus
{
	Operational,        // Normal operation
	Maintenance,        // Scheduled maintenance
	Faulty,             // Broken/faulty
	UnderPerforming,    // Underperforming
	Offline,            // Offline/stopped
	Commissioning,      // Being commissioned
	Decommissioned      // Permanently decommissioned
}