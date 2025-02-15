using MongoDBCars.Utils.Decorators;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MongoDBCars.Models
{
    public class Client : Entity<Client>
    {
        [RequiredField]
        public string Name { get; set; } = null!;
        [RequiredField]
        public string Email { get; set; } = null!;
        [RequiredField]
        [PasswordValidation]
        public string Password { get; set; } = null!;
        public Collection<Car> Cars { get; set; } = [];

        public Client? Create(string? name, string? email, string? password)
        {
            Client client = new()
            {
                Name = name!,
                Email = email!,
                Password = password!
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(client, new ValidationContext(client), validationResults, true);

            if (!isValid)
            {
                foreach (var validationResult in validationResults) Console.WriteLine(validationResult.ErrorMessage);
                return null;
            }
            else { 
                return client;
            }
        }
    }
}
