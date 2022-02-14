using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public  class Validator
    {
        public static void ThrowIfNumberNotInRange(int min,int max, int number , string errorMassage)
        {
            if (number<min || number>max)
            {
                throw new ArgumentException(errorMassage);
            }
            
        }

        public static void ThrowIfValueIsNotAllowed(HashSet<string> allowedValues,string value ,string errorMassage)
        {
            if (!allowedValues.Contains(value))
            {
                throw new ArgumentException(errorMassage);
            }
        }
    }
}
