using EnergyPortal.Domain.Common;

namespace EnergyPortal.Domain.Sites;

public sealed class Site : BaseEntity
{
	public string Name { get; private set; } = string.Empty!;
	public Location Location { get; private set; } = default!;
	//public Capacity TotalCapacity { get; private set; } = default!;

	private Site() { }

	internal Site(
		string name,
		Location location,
		//Capacity totalCapacity,
		string createdBy) : base(createdBy)
	{
		Name = name;
		Location = location;
		//TotalCapacity = totalCapacity;
	}

	public void Update(string name, Location location, string? updatedBy = null)
	{
		Name = name;
		Location = location;
		//TotalCapacity = new Capacity();
		SetUpdated(updatedBy);
	}
}
