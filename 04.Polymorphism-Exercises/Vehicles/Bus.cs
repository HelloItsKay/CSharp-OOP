using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public  class Bus:Vehicle
    {
        private const double AirConditionConsumption =1.4;
        

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
          
        }

        public bool isEmpty { get; set; }

        public override double FuelConsumption => isEmpty 
            ? base.FuelConsumption 
            : base.FuelConsumption + AirConditionConsumption;
    }
}
