using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        CarRepository cars = new CarRepository();
        RacerRepository racers = new RacerRepository();
        IMap map = new Map();

        public Controller()
        {
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            if (type == "SuperCar")
            {
                cars.Add(new SuperCar(make, model, VIN, horsePower));
            }

            if (type == "TunedCar")
            {
                cars.Add(new TunedCar(make, model, VIN, horsePower));
            }

            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var car = cars.Models.FirstOrDefault(c => c.VIN == carVIN);
            if (car is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            if (type == "ProfessionalRacer")
            {
                racers.Add(new ProfessionalRacer(username, car));
            }

            if (type == "StreetRacer")
            {
                racers.Add(new StreetRacer(username, car));
            }

            return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.Models.FirstOrDefault(r => r.Username == racerOneUsername);
            if (racerOne is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            var racerTwo = racers.Models.FirstOrDefault(r => r.Username == racerTwoUsername);
            if (racerTwo is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            return String.Join(Environment.NewLine, racers.Models.OrderByDescending(d => d.DrivingExperience).ThenBy(d => d.Username).Select(d => d.ToString()));
        }
    }
}
