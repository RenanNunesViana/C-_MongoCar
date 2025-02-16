using System.Text.RegularExpressions;

namespace MongoDBCars.Utils.Validations
{
    public static partial class StringExtensions
    {
        private static readonly Regex EmailRegex = EmailVerification();
        private static readonly Regex PasswordRegex = PasswordVerification();
        private static readonly Regex CarPlateRegex = CarPlateVerification();

        public static bool IsValidEmail(this string email)
        {
            return EmailRegex.IsMatch(email);
        }

        public static bool IsValidPassword(this string password)
        {
            return PasswordRegex.IsMatch(password);
        }

        public static bool IsValidCarPlate(this string plate)
        {
            return CarPlateRegex.IsMatch(plate);
        }

        [GeneratedRegex(@"[a-zA-Z0-9._-]{2,}@[a-z]{2,}(\.[a-z]{2,})+", RegexOptions.Compiled)]
        private static partial Regex EmailVerification();
        [GeneratedRegex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#_.])[0-9a-zA-Z$*&@#_.]{8,}$", RegexOptions.Compiled)]
        private static partial Regex PasswordVerification();
        [GeneratedRegex(@"^[A-Z]{3}-\d{4}$|^[A-Z]{3}\d[A-Z]\d{2}$", RegexOptions.Compiled)]
        private static partial Regex CarPlateVerification();
    }
}
