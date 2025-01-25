using CarTypo = MongoDBCars.Models.Car;

namespace MongoDBCars.Services.Car
{
    public interface ICarService
    {
        Task<List<CarTypo>> FindAllCars();
        Task<CarTypo> CreateCar(string brand, string color, string owner);
        Task<CarTypo> UpdateCar(string carId, string color, string owner);
        Task DeleteCar(string carId);
    }
}
