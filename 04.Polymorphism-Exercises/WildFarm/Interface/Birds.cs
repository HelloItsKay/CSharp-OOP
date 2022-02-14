using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Birds:Animal
    {
       
  protected Birds(string name, double weight, double wingSize) : base(name, weight)
  {
      WingSize = wingSize;
  }
        public double WingSize { get; }

      
    }
}
