using CarTypo = MongoDBCars.Models.Car;

namespace MongoDBCars.Services.Car
{
    public interface ICarService
    {
        Task<List<CarTypo>> FindAllCars();
    }
}
