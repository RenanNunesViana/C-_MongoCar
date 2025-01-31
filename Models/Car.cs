﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCars.Models
{
    [BsonIgnoreExtraElements]
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Brand { get; set; } = null!;

        public string Color { get; set; } = null!;
        public string Owner { get; set; } = null!;

    }
}