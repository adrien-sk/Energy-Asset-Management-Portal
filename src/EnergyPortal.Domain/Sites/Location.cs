namespace EnergyPortal.Domain.Sites;

public record Location(
	decimal Latitude,
	decimal Longitude,
	string Address,
	string City,
	string Region);