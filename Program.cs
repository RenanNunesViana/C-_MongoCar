using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDBCars.Models;
using MongoDBCars.Repositories;
using MongoDBCars.Services.Car;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CarStoreDatabaseSettings>(
    builder.Configuration.GetSection("CarStoreDatabase"));

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
Console.WriteLine($"Ambiente atual: {environment}");

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

//builder.Services.AddIdentityServer()
//    .AddInMemoryClients(new List<Client>
//    {
//        new Client
//        {
//            ClientId = "client",
//            AllowedGrantTypes = GrantTypes.ClientCredentials,
//            ClientSecrets =
//            {
//                new Secret("secret".Sha256())
//            },
//            AllowedScopes = { "api1" }
//        }
//    })
//    .AddInMemoryApiScopes(new List<ApiScope>
//    {
//        new ApiScope("api1", "My API")
//    })
//    .AddTestUsers(new List<TestUser>
//    {
//        new TestUser
//        {
//            SubjectId = "1",
//            Username = "test",
//            Password = "password"
//        }
//    });


var app = builder.Build();

//app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
