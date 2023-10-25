using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Games.API.Models;

public class Game
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("Title")]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public string? Publisher { get; set; }
}
