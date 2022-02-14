using System;
using ValidationAttributes.Models;

namespace ValidationAttributes
{
    
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var person = new Person
             (
                 "ivan",
                 -1
             );

            bool isValidEntity = Models.Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
