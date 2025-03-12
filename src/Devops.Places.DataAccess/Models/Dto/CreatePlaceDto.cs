namespace Devops.Places.DataAccess.Models.Dto;

public sealed class CreatePlaceDto
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public required GeoLocationDto Location { get; set; }
}