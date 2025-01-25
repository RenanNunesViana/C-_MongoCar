using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCars.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = null!;

        [BsonElement("idade")]
        public int Idade { get; set; }

        [BsonElement("CarBrand")]
        public string Brand { get; set; } = null!;

        public string Color { get; set; } = null!;
        public string Owner { get; set; } = null!;

    }
}
