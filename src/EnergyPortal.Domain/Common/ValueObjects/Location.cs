namespace EnergyPortal.Domain.Common.ValueObjects;

public record Location
{
	public decimal Latitude { get; }
	public decimal Longitude { get; }
	public string? Address { get; }
	public string? City { get; }
	public string? Region { get; }
}