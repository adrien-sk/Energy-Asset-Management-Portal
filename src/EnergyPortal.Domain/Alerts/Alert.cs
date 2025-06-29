using EnergyPortal.Domain.Common;

namespace EnergyPortal.Domain.Alerts;

public class Alert : BaseEntity
{
	public Guid SiteId { get; private set; }
	public Guid AssetId { get; private set; }
	public AlertType Type { get; private set; }
	public AlertSeverity Severity { get; private set; }
	public string Title { get; private set; } = string.Empty;
	public string Message { get; private set; } = string.Empty;
	public bool IsResolved { get; private set; }
	public DateTime? ResolvedAt { get; private set; }
	public string? ResolvedBy { get; private set; }
	public string? ResolutionNotes { get; private set; }

	// Private constructor for EF Core
	private Alert() { }
}
