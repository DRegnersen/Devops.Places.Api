using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devops.Places.DataAccess.Models;

internal sealed class Place
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;

    [BsonElement("name")]
    public string Name { get; set; } = default!;

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("location")]
    public GeoLocation Location { get; set; } = default!;
}

internal sealed class GeoLocation
{
    [BsonElement("latitude")]
    public double Latitude { get; set; }

    [BsonElement("longitude")]
    public double Longitude { get; set; }
}