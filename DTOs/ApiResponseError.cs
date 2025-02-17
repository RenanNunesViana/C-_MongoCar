using MongoDBCars.Enums;
using MongoDBCars.Utils;

namespace MongoDBCars.DTOs
{
    public class ApiResponseError
    {
        public ApiError Code { get; set; }
        public string Message => Code.GetDescription();


    }
}
