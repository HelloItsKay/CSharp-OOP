using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                FuelConsumption = fuelConsumption;
                FuelQuantity = 0;
                TankCapacity = tankCapacity;
            }
            else
            {
                FuelConsumption = fuelConsumption;
                FuelQuantity = fuelQuantity;
                TankCapacity = tankCapacity;
            }


        }

        public double FuelQuantity { get; protected set; }
        public virtual double FuelConsumption { get; }
        public double TankCapacity { get; }


        public bool CanDrive(double distance)
        {

            bool canDrive = FuelQuantity - FuelConsumption * distance >= 0;
            if (!canDrive)
            {
                return false;
            }

            FuelQuantity -= FuelConsumption * distance;
            return true;


        }

        public virtual void Refuel(double amount)
        {
           
            if (amount > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                if (amount<=0)
                {
                    Console.WriteLine($"Fuel must be a positive number");
                }
                else
                {
                     FuelQuantity += amount;
                }
               
            }


        }
    }
}
