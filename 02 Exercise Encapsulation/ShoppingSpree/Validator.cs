using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
   public class Validator
   {
       public static void ThrowIfStringIsNullOrEmpty(string str, string exeptionMassage)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exeptionMassage);
            }
        }

       public static void ThrowIfNumberIsNegative(decimal number, string exeptionMassage)
       {
           if (number<0)
           {
               throw  new ArgumentException(exeptionMassage);
           }
       }
    }
}
