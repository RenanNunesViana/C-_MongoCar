using MongoDB.Bson.Serialization.Attributes;
using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Utils.Validations;

namespace MongoDBCars.Models
{
    [BsonIgnoreExtraElements]
    public class Car : Entity<Car>
    {
        public string Brand { get; set; } = null!;
        public string CarPlate { get; set; } = null!;
        public string? Color { get; set; } = null!;

        public Car() { }

        public static Result<Car> Create(string? brand, string? carPlate, string? color)
        {

            List<ApiError> errors = Validation(brand, carPlate, color);

            if (errors.Count > 0)
            {
                return errors;
            }

            return new Car()
            {
                Brand = brand!,
                CarPlate = carPlate!,
                Color = color
            };
        }

        public Result<Car> Edit(string? brand, string? carPlate, string? color)
        {
            List<ApiError> errors = Validation(brand, carPlate, color);

            if(errors.Count > 0) return errors;

            Brand = brand!;
            CarPlate = carPlate!;
            Color = color!;
            
            return this;
        }

        private static List<ApiError> Validation(string? brand, string? carPlate, string? color)
        {
            List<ApiError> errors = [];
            if (string.IsNullOrWhiteSpace(brand))
            {
                errors.Add(ApiError.BRAND_IS_REQUIRED);
            }
            if (string.IsNullOrWhiteSpace(carPlate))
            {
                errors.Add(ApiError.CARPLATE_IS_REQUIRED);
            }
            else if (!carPlate.IsValidCarPlate())
            {
                errors.Add(ApiError.INVALID_CAR_PLATE);
            }
            // Maybe a enum?
            //if (check if color is a valid color) 
            //{
            //    errors.Add(ApiError.INVALID_COLOR)
            //}

            return errors;
        }
    }
}