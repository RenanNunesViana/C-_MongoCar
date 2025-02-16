using System.ComponentModel;

namespace MongoDBCars.Enums
{
    public enum ApiError
    {
        // Generic Errors
        [Description("Some unexpected thing heppened")]
        SOME_THING_GOES_WRONG = 0,

        // Cars Errrors
        [Description("Brand is a required field")]
        BRAND_IS_REQUIRED = 1,
        [Description("Car Plate is a required field")]
        CARPLATE_IS_REQUIRED = 2,
        [Description("There is not any car refeerenced by id passed")]
        CAR_NOT_FOUND_ID = 3,
        [Description("Client name is a required field")]
        CLIENT_NAME_EMPTY = 4,
        [Description("Client email is a required field")]
        CLIENT_EMAIL_EMPTY = 5,
        [Description("Password must have at least 8 characters, 1 lower an uppercase char and 1 special char")]
        STRONG_PASSWORD_REQUIRED = 6,
        [Description("Client password is a required field")]
        PASSWORD_REQUIRED = 7,
        [Description("Email should be a valid one")]
        INVALID_EMAIL = 8,
        [Description("Car plate should be a valid one")]
        INVALID_CAR_PLATE = 9,
    }
}
