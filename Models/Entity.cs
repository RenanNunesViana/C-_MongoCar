using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBCars.Models
{
    public class Entity<T> where T : class
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Entity() { }
        public override bool Equals(object? obj)
        {
            return obj is Entity<T> entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
