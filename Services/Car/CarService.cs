
using MongoDBCars.Repositories;

namespace MongoDBCars.Services.Car
{
    public class CarService(ICarRepository carRepository) : ICarService
    {

        private readonly ICarRepository _carRepository = carRepository;
        public async Task<List<Models.Car>> FindAllCars() => await _carRepository.FindAll();
    }
}
