namespace EnergyPortal.Domain.Common;

public abstract class BaseEntity
{
	public Guid Id { get; protected set; } = Guid.NewGuid();
	public DateTime CreatedAt { get; protected set; } = DateTime.Now;
	public DateTime? UpdatedAt { get; protected set; }
	public string? CreatedBy { get; protected set; }
	public string? UpdatedBy { get; protected set; }

	protected void SetUpdated(string? updatedBy = null)
	{
		UpdatedAt = DateTime.Now;
		UpdatedBy = updatedBy;
	}
}
