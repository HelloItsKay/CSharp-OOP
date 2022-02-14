using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat: Animal
    {
        public Cat(string name, string favoriteFood) : base(name, favoriteFood)
        {
        }

        public virtual string ExplainSelf()
        {
            return $" {base.ExplainSelf()}\nMEEOW";
            
        }
    }
}
