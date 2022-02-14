using System;
using System.Collections.Generic;
using System.Text;
using WildFarm;


namespace WildFarm
{
   public class Dog:Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
