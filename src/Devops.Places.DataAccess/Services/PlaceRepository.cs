using Devops.Places.DataAccess.Models;
using Devops.Places.DataAccess.Models.Dto;
using Devops.Places.DataAccess.Models.Options;
using Devops.Places.DataAccess.Services.Abstractions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Devops.Places.DataAccess.Services;

internal sealed class PlaceRepository(IMongoClient client, IOptions<MongoDbOptions> options) : IPlaceRepository
{
    private readonly IMongoCollection<Place> _collection = client.GetDatabase(options.Value.Database).GetCollection<Place>("places");

    public async Task<PlaceDto> CreatePlaceAsync(CreatePlaceDto place, CancellationToken cancellationToken = default)
    {
        var placeDocument = Mapper.Map(place);
        await _collection.InsertOneAsync(placeDocument, cancellationToken: cancellationToken);

        return Mapper.Map(placeDocument);
    }

    public async Task<PlaceDto[]> GetPlacesAsync(int? maxPlaces = null, CancellationToken cancellationToken = default)
    {
        var places = await GetPlacesInternalAsync(maxPlaces, cancellationToken);

        return places.Select(Mapper.Map).ToArray();
    }

    private async Task<List<Place>> GetPlacesInternalAsync(int? maxPlaces, CancellationToken cancellationToken)
    {
        if (maxPlaces.HasValue)
        {
            return await _collection
                .Aggregate()
                .Sample(maxPlaces.Value)
                .ToListAsync(cancellationToken: cancellationToken);
        }

        return await _collection.Find(FilterDefinition<Place>.Empty).ToListAsync(cancellationToken);
    }
}

#region Mappings

file static class Mapper
{
    public static Place Map(CreatePlaceDto place) => new()
    {
        Name = place.Name,
        Description = place.Description,
        Location = Map(place.Location)
    };

    public static PlaceDto Map(Place place) => new()
    {
        Id = place.Id,
        Name = place.Name,
        Description = place.Description,
        Location = Map(place.Location)
    };

    private static GeoLocation Map(GeoLocationDto geoLocation) => new()
    {
        Latitude = geoLocation.Latitude,
        Longitude = geoLocation.Longitude
    };

    private static GeoLocationDto Map(GeoLocation geoLocation) => new()
    {
        Latitude = geoLocation.Latitude,
        Longitude = geoLocation.Longitude
    };
}

#endregion