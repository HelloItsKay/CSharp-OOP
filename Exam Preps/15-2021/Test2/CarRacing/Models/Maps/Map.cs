using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            //MOJE DA GYRMI
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            double firstMulti = 0;
            double secondMulti = 0;

            if (racerOne.RacingBehavior == "agressive")
            {
                firstMulti = 1.1;
            }
            else
            {
                firstMulti = 1.2;
            }

            if (racerTwo.RacingBehavior == "agressive")
            {
                secondMulti = 1.1;
            }
            else
            {
                secondMulti = 1.2;
            }

            double first = racerOne.Car.HorsePower * racerOne.DrivingExperience*firstMulti;
            double second = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * secondMulti;
            racerOne.Race();
            racerTwo.Race();

            if (first > second)
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }

        }
    }
}
