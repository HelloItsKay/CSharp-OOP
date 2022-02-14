using System.Reflection;
using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes.Models
{
   public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var customAtt = (MyValidationAttribute)property.GetCustomAttribute(typeof(MyValidationAttribute), false);
                bool isValid = customAtt.IsValid(property.GetValue(obj));

                if (!isValid)
                {
                    return false;
                }

            }

            return false;
        }
    }
}
