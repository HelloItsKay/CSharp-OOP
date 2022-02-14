using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        //public Coffee(string name, double caffeine, decimal price = 3.5M, double milliliters = 50)
        //    : base(name, price, milliliters)

        private const double defaultMilliliters = 50;
        private const decimal defaultPrice = 3.5M;
        public Coffee(string name, double caffeine)
            : base(name, defaultPrice, defaultMilliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}