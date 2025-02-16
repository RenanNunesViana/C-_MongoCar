using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Utils.Validations;
using System.Collections.ObjectModel;

namespace MongoDBCars.Models
{
    public class Client : Entity<Client>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Collection<Car> Cars { get; set; } = [];

        private Client() { }

        public Result<Client>? Create(string? name, string? email, string? password)
        {

            List<ApiError> errors = Validation(name, email, password);
            if (errors.Count > 0)
            {
                return errors;
            }

            Client client = new()
            {
                Name = name!,
                Email = email!,
                Password = password!
            };
            return client;
        }

        private static List<ApiError> Validation(string? name, string? email, string? password)
        {
            List<ApiError> errors = [];

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add(ApiError.CLIENT_NAME_EMPTY);
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add(ApiError.CLIENT_EMAIL_EMPTY);
            }
            else
            {
                if (!email.IsValidEmail())
                {
                    errors.Add(ApiError.INVALID_EMAIL);
                }
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add(ApiError.PASSWORD_REQUIRED);
            }
            else
            {
                if (!password.IsValidPassword())
                {
                    errors.Add(ApiError.STRONG_PASSWORD_REQUIRED);
                }
            }

            return errors;
        }
    }
}
