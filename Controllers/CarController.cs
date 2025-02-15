using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDBCars.Models;
using MongoDBCars.Services.Car;

namespace MongoDBCars.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarController(ICarService carService) : ControllerBase
    {
        readonly ICarService _carService = carService;

        [HttpGet]
        [Authorize]
        public Task<List<Car>> RequestAllCars()

        {
            return _carService.FindAllCars();
        }

        [HttpPost]
        public async Task<Car> CreateCar([FromBody] Car car)
        {
            return await _carService.CreateCar(car.Brand, car.CarPlate, car.Color);
        }

        [HttpPut]
        public async Task<Car> UpdateCar([FromQuery] string id, [FromBody] Car car)
        {
            return await _carService.UpdateCar(id, car.CarPlate, car.Color);
        }

        [HttpDelete]
        public async Task RemoveCar([FromQuery] string id)
        {
            await _carService.DeleteCar(id);
        }
    }
}
