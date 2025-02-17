using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDBCars.DTOs;
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
        public async Task<ActionResult<List<Car>>> RequestAllCars()
        {
            var carsResult = await _carService.FindAllCars();
            if (carsResult.ItsFailure)
            {
                return BadRequest(ApiResponse<List<Car>>.GenerateFailure(carsResult.Errors));
            }
            return Ok(ApiResponse<List<Car>>.GenerateSuccess(carsResult.Value!));
        }

        [HttpPost]
        public async Task<ActionResult<Car?>> CreateCar([FromBody] Car car)
        {
            var createResult = await _carService.CreateCar(car.Brand, car.CarPlate, car.Color);

            if (createResult.ItsFailure) return BadRequest(ApiResponse<Car>.GenerateFailure(createResult.Errors));
            return Ok(ApiResponse<Car>.GenerateSuccess(createResult.Value!));
        }

        [HttpPut]
        public async Task<ActionResult<Car>> UpdateCar([FromQuery] string id, [FromBody] Car car)
        {
            var updateResult = await _carService.UpdateCar(id, car.CarPlate, car.Color);
            if(updateResult.ItsFailure) return BadRequest(ApiResponse<Car>.GenerateFailure(updateResult.Errors));
            return Ok(ApiResponse<Car>.GenerateSuccess(updateResult.Value!));
        }

        [HttpDelete]
        public async Task RemoveCar([FromQuery] string id)
        {
            await _carService.DeleteCar(id);
        }
    }
}
