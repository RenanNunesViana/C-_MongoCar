using MongoDBCars.DTOs;
using CarTypo = MongoDBCars.Models.Car;

namespace MongoDBCars.Services.Car
{
    public interface ICarService
    {
        Task<Result<List<CarTypo>>> FindAllCars();
        Task<Result<CarTypo>> CreateCar(string brand, string? carPlate, string? color);
        Task<Result<CarTypo>> UpdateCar(string carId, string? carPlate, string? color);
        Task DeleteCar(string carId);
    }
}
