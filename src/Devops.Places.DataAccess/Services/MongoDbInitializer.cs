using Devops.Places.DataAccess.Models;
using Devops.Places.DataAccess.Models.Options;
using Devops.Places.DataAccess.Services.Abstractions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Devops.Places.DataAccess.Services;

internal sealed class MongoDbInitializer(IMongoClient client, IOptions<MongoDbOptions> options) : IMongoDbInitializer
{
    private readonly IMongoCollection<Place> _placesCollection = client.GetDatabase(options.Value.Database).GetCollection<Place>("places");

    public async Task InitializeAsync()
    {
        if (await _placesCollection.CountDocumentsAsync(FilterDefinition<Place>.Empty) == 0)
        {
            var places = new List<Place>
            {
                new() { Name = "Eiffel Tower", Description = "Paris, France", Location = new GeoLocation { Latitude = 48.8584, Longitude = 2.2945 } },
                new() { Name = "Statue of Liberty", Description = "New York, USA", Location = new GeoLocation { Latitude = 40.6892, Longitude = -74.0445 } }
            };

            await _placesCollection.InsertManyAsync(places);
        }
    }
}