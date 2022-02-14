using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> indentifiables = new List<IIdentifiable>();
            List<IBirthdays> birthdays = new List<IBirthdays>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End") break;
                string[] parts = line.Split();
                if (parts[0] == "Citizen")
                {
                    string name = parts[1];
                    int age = Convert.ToInt32(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];
                    indentifiables.Add(new Citizen(name, age, id, birthdate));
                    birthdays.Add(new Citizen(birthdate, age, id, birthdate));

                }
                else if (parts[0] == "Robot")
                {
                    string model = parts[1];
                    string id = parts[2];
                    indentifiables.Add(new Robot(model, id));
                }
                else
                {
                    string name = parts[1];
                    string birthday = parts[2];
                    birthdays.Add(new Pet(name, birthday));

                }
            }

            string filterId = Console.ReadLine();

            List<IBirthdays> filtered = birthdays.Where(i => i.Birthdate.Contains(filterId)).ToList();
            foreach (var item in filtered)
            {

                Console.WriteLine(item.Birthdate);



            }
        }
    }
}
