using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            //List<Person>people=new List<Person>();

            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine().Split();
            //    people.Add(new Person(input[0],input[1],int.Parse(input[2])));
            //}

            //people.OrderBy(p => p.FirstName).ThenBy(a => a.Age).ToList();

            //foreach (var person in people)
            //{
            //    Console.WriteLine(person);
            //}

            try
            {

            var lines = int.Parse(Console.ReadLine());
            var persons = new List< Person> ();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]));
                persons.Add(person);
            }
            var parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
