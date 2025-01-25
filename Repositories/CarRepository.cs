using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBCars.Models;

namespace MongoDBCars.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCollection<Car> _carCollection;

        public CarRepository(IOptions<CarStoreDatabaseSettings> carStoreOpt)
        {

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
            Console.WriteLine($"Ambiente atual: {environment}");

            if (carStoreOpt == null || carStoreOpt.Value == null)
            {
                Console.WriteLine("carStoreOpt ou carStoreOpt.Value está nulo!");
                throw new ArgumentNullException("Configuração do banco faltante");
            }
            else
            {
                Console.WriteLine($"ConnectionString: {carStoreOpt.Value.ConnectionString}");
            }

            var mongoClient = new MongoClient(carStoreOpt.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(carStoreOpt.Value.DatabaseName);

            _carCollection = mongoDatabase.GetCollection<Car>(carStoreOpt.Value.CarsCollectionName);
        }
        public Task DeleteCar(Car car)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Car>> FindAll() => await _carCollection.Find(_ =>  true).ToListAsync();

        public Task<List<Car>> FindByAnyThing(Action<Car> func)
        {
            throw new NotImplementedException();
        }

        public Task<Car> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Car> UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
