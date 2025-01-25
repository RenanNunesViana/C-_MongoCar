using Microsoft.AspNetCore.Mvc;
using MongoDBCars.Models;
using MongoDBCars.Services.Car;

namespace MongoDBCars.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarController(ICarService carService) : ControllerBase
    {
        readonly ICarService carService = carService;

        [HttpGet]
        public Task<List<Car>> RequestAllCars()
        
        {
            return carService.FindAllCars();
        }

        [HttpPost]
        public async Task<Car> CreateCar([FromBody] Car car)
        {
            return await Task.FromResult(car);
        }

        [HttpPut]
        public Task<Car> UpdateCar([FromBody] Car car)
        {
            return Task.FromResult(car);
        }
    }
}
