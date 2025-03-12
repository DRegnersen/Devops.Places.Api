using Devops.Places.Api.Endpoints.Abstractions;
using Devops.Places.Api.Models;
using Devops.Places.Api.Models.CreatePlace;
using Devops.Places.DataAccess.Models.Dto;
using Devops.Places.DataAccess.Services.Abstractions;

namespace Devops.Places.Api.Endpoints;

public sealed class CreatePlaceEndpoint(IPlaceRepository repository) : IEndpoint<CreatePlaceRequest, CreatePlaceResponse>
{
    public async ValueTask<CreatePlaceResponse> InvokeAsync(CreatePlaceRequest request, CancellationToken cancellationToken)
    {
        var place = await repository.CreatePlaceAsync(Mapper.Map(request), cancellationToken);
        return Mapper.Map(place);
    }
}

#region Mappings

file static class Mapper
{
    public static CreatePlaceDto Map(CreatePlaceRequest placeToCreate) => new()
    {
        Name = placeToCreate.Name,
        Description = placeToCreate.Description,
        Location = Map(placeToCreate.Location)
    };

    public static CreatePlaceResponse Map(PlaceDto place) => new()
    {
        PlaceId = place.Id,
        Name = place.Name,
        Description = place.Description,
        Location = Map(place.Location)
    };

    private static GeoLocationDto Map(GeoLocationModel geoLocation) => new()
    {
        Latitude = geoLocation.Latitude,
        Longitude = geoLocation.Longitude
    };

    private static GeoLocationModel Map(GeoLocationDto geoLocation) => new()
    {
        Latitude = geoLocation.Latitude,
        Longitude = geoLocation.Longitude
    };
}

#endregion