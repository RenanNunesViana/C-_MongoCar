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

            if (carStoreOpt == null || carStoreOpt.Value == null)
            {
                Console.WriteLine("carStoreOpt ou carStoreOpt.Value está nulo!");
                throw new ArgumentNullException("Configuração do banco faltante");
            }
            else
            {
                var mongoClient = new MongoClient(carStoreOpt.Value.ConnectionString);

                var mongoDatabase = mongoClient.GetDatabase(carStoreOpt.Value.DatabaseName);

                _carCollection = mongoDatabase.GetCollection<Car>(carStoreOpt.Value.CarsCollectionName);
            }
        }

        public async Task Create(Car car)
        {
            try
            {
                await _carCollection.InsertOneAsync(car);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCar(string id) => await _carCollection.DeleteOneAsync(c => c.Id!.Equals(id));

        public async Task<List<Car>> FindAll() {
            try
            {
                return await _carCollection.Find(_ => true).ToListAsync(); 
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return [];
            }
        }

        public Task<List<Car>> FindByAnyThing(Action<Car> func)
        {
            throw new NotImplementedException();
        }

        public async Task<Car?> FindById(string id) => await _carCollection.Find(c => c.Id!.Equals(id)).FirstOrDefaultAsync();

        public async Task UpdateCar(string id, Car updatedCar) => await _carCollection.ReplaceOneAsync(c => c.Id!.Equals(id), updatedCar);
    }
}
