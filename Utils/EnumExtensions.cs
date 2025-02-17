using System.ComponentModel;
using System.Reflection;

namespace MongoDBCars.Utils
{
    public static class EnumExtensions
    {
        public static bool HasValue(this Enum value)
        {
            return value != null && Enum.IsDefined(value?.GetType(), value);
        }
        public static string GetDescription(this Enum value)
        {
            var hasValue = HasValue(value);
            if (hasValue) 
            {
                FieldInfo? field = value.GetType().GetField(value.ToString());

                return Attribute.GetCustomAttribute(field!, typeof(DescriptionAttribute)) is not DescriptionAttribute attribute ? value.ToString() : attribute.Description;
            }
            return string.Empty;
        }
    }
}