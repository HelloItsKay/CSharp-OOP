using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Core
{
   public class Controller:IController

   {
       private readonly IRepository<ICar> carRepository;
       private readonly IRepository<IRacer> racersRepository;



        public Controller()
       {
          carRepository=new CarRepository();
          racersRepository=new RacerRepository();
       }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {


            if (type == "SuperCar")
            {
                SuperCar thisOne = new SuperCar(make, model, VIN, horsePower);
                carRepository.Add(thisOne);
                return $"Successfully added car {make} {model} ({VIN}).";
            }
            if (type == "TunedCar")
            {
                TunedCar thisOne = new TunedCar(make, model, VIN, horsePower);
                carRepository.Add(thisOne);
                return $"Successfully added car {make} {model} ({VIN}).";
            }
            throw new ArgumentException(ExceptionMessages.InvalidCarType);

        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            ICar desiredCar = carRepository.FindBy(carVIN);
            if (desiredCar is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            IRacer racer = default;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username,desiredCar);
            }
            else if (type == "StreetRacer")
            {
                racer=new StreetRacer(username,desiredCar);
            }
            racersRepository.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer,username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer first = racersRepository.FindBy(racerOneUsername);
            IRacer second = racersRepository.FindBy(racerTwoUsername);
            Map thisOne = new Map();
            if (second == null)
            {
                return $"Racer {racerTwoUsername} cannot be found!";
            }
            if (first == null)
            {
                return $"Racer {racerOneUsername} cannot be found!";
            }

            return thisOne.StartRace(first, second);

        }

        public string Report()
        {
           StringBuilder sb=new StringBuilder();
           var sortedDictionay = racersRepository.Models.OrderByDescending(d => d.DrivingExperience)
               .ThenBy(r => r.Username);

           foreach (var racer in sortedDictionay)
           {
                sb.AppendLine($"{ racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
           }

           return sb.ToString().TrimEnd();
        }
    }
}
