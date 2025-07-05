namespace EnergyPortal.Domain.Common;

public abstract class BaseEntity
{
	public Guid Id { get; protected set; } = Guid.NewGuid();
	public DateTime CreatedAt { get; protected set; } = DateTime.Now;
	public DateTime? UpdatedAt { get; protected set; }
	public string? CreatedBy { get; protected set; }
	public string? UpdatedBy { get; protected set; }


	protected BaseEntity() { }

	protected BaseEntity(string createdBy)
	{
		CreatedBy = createdBy;
	}

	public override bool Equals(object? obj)
	{
		if (obj == null) return false;

		if (obj.GetType() != GetType()) return false;

		if (obj is not BaseEntity entity) return false;

		return entity.Id == Id;
	}

	public override int GetHashCode() => Id.GetHashCode();

	protected void SetUpdated(string? updatedBy = null)
	{
		UpdatedAt = DateTime.Now;
		UpdatedBy = updatedBy;
	}
}
