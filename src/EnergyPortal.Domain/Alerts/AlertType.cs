namespace EnergyPortal.Domain.Alerts;

public enum AlertType
{
	// Technical Issues
	EquipmentFailure,       // Equipment breakdown
	PerformanceDrop,        // Performance decline
	MaintenanceRequired,    // Maintenance needed
	CommunicationLoss,      // Communication loss

	// Operational Issues
	OverTemperature,        // Overheating
	UnderPerformance,       // Underperformance
	GridConnection,         // Electrical grid issue
	SafetyIssue,            // Safety concern

	// System Alerts
	DataQuality,            // Data quality issue
	SystemHealth,           // System health issue
	ConfigurationChange,    // Configuration change

	// Weather/Environmental Alerts
	WeatherImpact,          // Weather impact
	EnvironmentalIssue      // Environmental issue
}