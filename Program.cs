using MongoDBCars.Models;
using MongoDBCars.Repositories;
using MongoDBCars.Services.Car;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.Configure<CarStoreDatabaseSettings>(
    builder.Configuration.GetSection("CarStoreDatabase"));

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
