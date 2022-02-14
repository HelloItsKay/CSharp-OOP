using System;
using System.Data.SqlTypes;
using System.IO;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carTokens = Console.ReadLine().Split();
            var truckToken = Console.ReadLine().Split();
            var busToken = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
            Vehicle truck = new Truck(double.Parse(truckToken[1]), double.Parse(truckToken[2]), double.Parse(truckToken[3]));
            Bus bus = new Bus(double.Parse(busToken[1]), double.Parse(busToken[2]), double.Parse(busToken[3]));


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine().Split();

                var command = currentLine[0];
                var type = currentLine[1];
                var amount = double.Parse(currentLine[2]);
                bool hi = false;
                if (command is "Drive")
                {
                    if (type is "Car")
                    {
                        CanDrive(car, amount);
                    }
                    else if (type is "Bus")
                    {
                        bus.isEmpty = false;
                        CanDrive(bus,amount);
                    }
                    else
                    {
                        CanDrive(truck, amount);
                    }
                }
                else if (command is "DriveEmpty")
                {
                    bus.isEmpty = true;
                    CanDrive(bus,amount);
                }
                else
                {
                    if (type is "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (type is "Bus")
                    {
                        
                        bus.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string result = canDrive
                ? $"{vehicle.GetType().Name} travelled {distance} km"
                : $"{vehicle.GetType().Name} needs refueling";
            Console.WriteLine(result);
        }
    }


}
