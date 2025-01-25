using MongoDBCars.Models;

namespace MongoDBCars.Repositories
{
    public interface ICarRepository
    {
        Task<Car> FindById(string id);
        Task<List<Car>> FindAll();
        Task<List<Car>> FindByAnyThing(Action<Car> func);
        Task<Car> UpdateCar(Car car);
        Task DeleteCar(Car car);

    }
}
