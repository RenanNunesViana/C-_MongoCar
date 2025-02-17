using MongoDBCars.Enums;

namespace MongoDBCars.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Value { get; set; }
        public List<ApiResponseError> Errors { get; set; } = [];

        public static ApiResponse<T> GenerateSuccess(T value)
        {
            return new ApiResponse<T> { Success = true, Value = value };
        }

        public static ApiResponse<T> GenerateFailure(List<ApiError> errors)
        {
            var apiErrors = errors.Select(e => new ApiResponseError { Code = e }).ToList();
            return new ApiResponse<T> { Success = false, Errors = apiErrors };
        }
    }
}
