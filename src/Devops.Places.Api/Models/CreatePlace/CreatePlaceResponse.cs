namespace Devops.Places.Api.Models.CreatePlace;

public sealed class CreatePlaceResponse
{
    public required string PlaceId { get; set; }
    
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public required GeoLocationModel Location { get; set; }
}