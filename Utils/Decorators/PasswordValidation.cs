using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MongoDBCars.Utils.Decorators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public partial class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            List<string> errors = [];

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("A senha não pode ser nula ou vazia.");
            }

            var password = value.ToString();

            // Verifica o comprimento mínimo
            if (password!.Length < 8)
            {
                return new ValidationResult("A senha deve ter pelo menos 8 caracteres.");
            }

            // Verifica se contém pelo menos uma letra maiúscula
            if (!UpperCaseRegex().IsMatch(password))
            {
                return new ValidationResult("A senha deve conter pelo menos uma letra maiúscula.");
            }

            // Verifica se contém pelo menos uma letra minúscula
            if (!LowerCaseRegex().IsMatch(password))
            {
                return new ValidationResult("A senha deve conter pelo menos uma letra minúscula.");
            }

            // Verifica se contém pelo menos um número
            if (!NumberRegex().IsMatch(password))
            {
                return new ValidationResult("A senha deve conter pelo menos um número.");
            }

            // Verifica se contém pelo menos um caractere especial
            if (!EspecialRegex().IsMatch(password))
            {
                return new ValidationResult("A senha deve conter pelo menos um caractere especial.");
            }

            return ValidationResult.Success;
        }

        [GeneratedRegex("[A-Z]")]
        private static partial Regex UpperCaseRegex();
        [GeneratedRegex("[a-z]")]
        private static partial Regex LowerCaseRegex();
        [GeneratedRegex("[0-9]")]
        private static partial Regex NumberRegex();
        [GeneratedRegex("[^a-zA-Z0-9]")]
        private static partial Regex EspecialRegex();
    }
}
