using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raid = new List<BaseHero>();
            for (int i = 0; i < n; i++)
            {
                here:
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();
                int power = 0;
                if (heroType is "Druid")
                {
                    power = 80;
                    raid.Add(new Druid(name, power));
                }
                else if (heroType is "Paladin")
                {
                    power = 100;
                    raid.Add(new Paladin(name, power));
                }
                else if (heroType is "Rogue")
                {
                    power = 80;
                    raid.Add(new Rogue(name, power));
                }
                else if (heroType is "Warrior")
                {
                    power = 100;
                    raid.Add(new Warrior(name, power));
                }
                else
                {
                    Console.WriteLine($"Invalid hero!");
                    goto here;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidPower = 0;

            foreach (var hero in raid)
            {
                hero.CastAbility();
                raidPower += hero.Power;
            }

            if (bossPower>raidPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine($"Victory!");
            }

            

        }
    }
}
