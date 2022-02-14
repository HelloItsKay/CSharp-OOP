using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionConsumption = 1.6;
      public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + AirConditionConsumption;
        public override void Refuel(double amount)
        {
            if (amount>TankCapacity)
            {
                 base.Refuel(amount);
            }
            else
            {
                base.Refuel(amount * 0.95);
            }

           
        }


        
    }
}
