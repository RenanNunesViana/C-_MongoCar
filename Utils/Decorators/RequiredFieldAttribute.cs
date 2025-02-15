using System.ComponentModel.DataAnnotations;

namespace MongoDBCars.Utils.Decorators
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredFieldAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult($"{validationContext.DisplayName} é obrigatório");
            return ValidationResult.Success;
        }
    }
}
