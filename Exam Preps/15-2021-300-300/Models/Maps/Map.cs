using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
        }

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            var racingBehaviorMultiplierRacerOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierRacerOne;

            var racingBehaviorMultiplierRacerTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierRacerTwo;

            if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
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
