using MongoDBCars.Enums;

namespace MongoDBCars.DTOs
{
    public class Result<T>
    {
        public List<ApiError> Errors { get; set; } = [];
        public T? Value { get; set; }


        private Result(T success)
        { 
            Value = success;
        }

        private Result(List<ApiError> errors)
        {
            Errors = errors;
        }

        public bool ItsFailure => Errors.Count > 0;

        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value);
        }

        public static implicit operator Result<T>(List<ApiError> errors)
        {
            return new Result<T>(errors);
        }
    }
}
