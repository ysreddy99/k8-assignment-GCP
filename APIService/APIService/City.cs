
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class City
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("country")]
    public string Country { get; set; } = null!;

    [BsonElement("population")]
    public long Population { get; set; }

    [BsonElement("latitude")]
    public decimal  Latitude { get; set; }

    [BsonElement("longitude")]
    public decimal  Longitude { get; set; }


}