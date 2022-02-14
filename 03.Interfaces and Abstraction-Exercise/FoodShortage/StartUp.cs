using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,IBuyer> buyersByName = new Dictionary<string, IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = Convert.ToInt32(parts[1]);
                    string group = parts[2];
                    buyersByName[name]=new Rebel(name, age, group);
                    
                }
                else
                {
                    string name = parts[0];
                    int age = Convert.ToInt32(parts[1 ]);
                    string id = parts[2];
                    string birthday = parts[3];

                    buyersByName[name] = new Citizen(name, age, id, birthday);
                }
            }


            while (true)
            {
                string lines = Console.ReadLine();
                if (lines == "End") break;

                if (!buyersByName.ContainsKey(lines))
                {
                    continue;
                }

                IBuyer buyer = buyersByName[lines];
                buyer.BuyFood();
            }

         
          Console.WriteLine(buyersByName.Values.Sum(b => b.Food));
        }
    }
}
