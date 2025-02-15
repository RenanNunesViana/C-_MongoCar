using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBCars.Utils.Decorators;
using System.ComponentModel.DataAnnotations;

namespace MongoDBCars.Models
{
    [BsonIgnoreExtraElements]
    public class Car : Entity<Car>
    {
        [RequiredField]
        public string Brand { get; set; } = null!;
        [RequiredField]
        public string CarPlate { get; set; } = null!;
        public string? Color { get; set; } = null!;

        public Car? Create(string? brand, string? carPlate, string? color)
        {
            Car car = new Car()
            {
                Brand = brand!,
                CarPlate = carPlate!,
                Color = color
            };

            var validatioResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(car, new ValidationContext(car), validatioResults, true);

            if (!isValid)
            {
                foreach (var validationResult in validatioResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
                return null;
            }
            else
            {
                return car;
            }
        }
    }
}