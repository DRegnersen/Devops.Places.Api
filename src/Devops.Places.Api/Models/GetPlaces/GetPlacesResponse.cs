namespace Devops.Places.Api.Models.GetPlaces;

public sealed class GetPlacesResponse
{
    public PlaceModel[] Places { get; set; } = [];
}

public sealed class PlaceModel
{
    public required string PlaceId { get; set; }
    
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public required GeoLocationModel Location { get; set; }
}