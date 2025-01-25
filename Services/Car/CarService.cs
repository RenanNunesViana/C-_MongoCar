
using MongoDBCars.Repositories;

namespace MongoDBCars.Services.Car
{
    public class CarService(ICarRepository carRepository) : ICarService
    {

        private readonly ICarRepository _carRepository = carRepository;

        public async Task<Models.Car> CreateCar(string brand, string color, string owner)
        {
            var newCar = new Models.Car { Brand = brand, Color = color, Owner = owner };
            await _carRepository.Create(newCar);
            return newCar;
        }

        public async Task DeleteCar(string carId)
        {
            await _carRepository.DeleteCar(carId);
        }

        public async Task<List<Models.Car>> FindAllCars() => await _carRepository.FindAll();

        public async Task<Models.Car> UpdateCar(string carId, string color, string owner)
        {
            var foundedCar = await _carRepository.FindById(carId);
            if (foundedCar != null)
            {
                var updatedCar = new Models.Car
                {
                    Id = carId,
                    Brand = foundedCar.Brand,
                    Color = color,
                    Owner = owner
                };
                await _carRepository.UpdateCar(carId, updatedCar);

                return updatedCar;
            }
            else
            {
                throw new NotImplementedException($"Carro com id {carId} não encontrado");
            }

        }
    }
}
