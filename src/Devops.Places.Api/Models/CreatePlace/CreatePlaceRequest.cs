using System.ComponentModel.DataAnnotations;

namespace Devops.Places.Api.Models.CreatePlace;

public sealed class CreatePlaceRequest
{
    [Required]
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    [Required]
    public required GeoLocationModel Location { get; set; }
}

