using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public class Owl:Birds
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
