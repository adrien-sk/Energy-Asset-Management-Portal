using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Common.ValueObjects;

namespace EnergyPortal.Domain.Sites;

public sealed class Site : BaseEntity
{
	public string Name { get; set; } = string.Empty!;
	public Location Location { get; set; } = new();
	public Capacity TotalCapacity { get; set; } = new();
	public DateTime? InstallationDate { get; set; }

	private readonly List<Asset> _assets = new();
	public List<Asset> Assets => _assets.ToList();

	public static Site Create(string name, Location location, string? createdBy = null)
	{
		var site = new Site()
		{
			Name = name,
			Location = location,
			TotalCapacity = new Capacity(),
		};
		site.SetCreated(createdBy);

		return site;
	}

	public void Update(string name, Location location, DateTime? installationDate = null, string? updatedBy = null)
	{
		Name = name;
		Location = location;
		TotalCapacity = new Capacity();
		InstallationDate = installationDate;
		SetUpdated(updatedBy);
	}
}
