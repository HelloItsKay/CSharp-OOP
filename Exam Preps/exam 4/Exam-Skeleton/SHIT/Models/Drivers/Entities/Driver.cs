using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers.Entities
{
   public class Driver : IDriver
   {
       private string name;

       public string Name
       {
           get => name;
           private set
           {
               if (string.IsNullOrEmpty(value) || value.Length < 5)
               {
                   throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
               }

               name = value;
           }
       }

       public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate => Car != null;

        public Driver(string name)
        {
            Name = name;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentNullException("Car cannot be null.");
            }

            this.Car = car;
        }
    }
}
