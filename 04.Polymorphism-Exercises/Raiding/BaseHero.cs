using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get;}
        public int Power { get; protected set; }

        public virtual void CastAbility()
        {
            if (base.GetType().Name is "Druid" || base.GetType().Name is "Paladin")
            {
                Console.WriteLine($"{base.GetType().Name} - {Name} healed for {Power}");
            }
            else
            {
                Console.WriteLine($"{base.GetType().Name} - {Name} hit for {Power} damage");
            }
            
        }
    }
}
