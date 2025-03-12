using Devops.Places.Api.Endpoints.Abstractions;
using Devops.Places.Api.Models;
using Devops.Places.Api.Models.GetPlaces;
using Devops.Places.DataAccess.Models.Dto;
using Devops.Places.DataAccess.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace Devops.Places.Api.Endpoints;

public sealed class GetPlacesEndpoint(IPlaceRepository repository, IOptions<GetPlacesOptions> options) : IEndpoint<GetPlacesRequest, GetPlacesResponse>
{
    private readonly GetPlacesOptions _options = options.Value;

    public async ValueTask<GetPlacesResponse> InvokeAsync(GetPlacesRequest request, CancellationToken cancellationToken)
    {
        var maxPlaces = request.MaxPlaces ?? _options.DefaultMaxPlaces;

        var places = await repository.GetPlacesAsync(maxPlaces, cancellationToken);
        return Mapper.Map(places);
    }
}

#region Mappings

file static class Mapper
{
    public static GetPlacesResponse Map(PlaceDto[] places) => new()
    {
        Places = places.Select(Map).ToArray()
    };

    private static PlaceModel Map(PlaceDto place) => new()
    {
        PlaceId = place.Id,
        Name = place.Name,
        Description = place.Description,
        Location = Map(place.Location)
    };

    private static GeoLocationModel Map(GeoLocationDto geoLocation) => new()
    {
        Latitude = geoLocation.Latitude,
        Longitude = geoLocation.Longitude
    };
}

#endregion