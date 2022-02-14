using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
  public  class Cat:Felines
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion,breed)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
