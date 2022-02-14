using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        public DecorationRepository decorations;
        public List<IAquarium> aquariums;


        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName) 
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = default;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium=new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);

        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = default;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration desiredDecoration = decorations.FindByType(decorationType);
            if (desiredDecoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }

            decorations.Remove(desiredDecoration);
            IAquarium desAquarium= aquariums.FirstOrDefault(x => x.Name == aquariumName);

            desAquarium.AddDecoration(desiredDecoration);
            //potential bug
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
            {
            //potential bug;==  !=
            if (fishType!=nameof(SaltwaterFish) && fishType != nameof(FreshwaterFish))
            {
                throw  new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish = default;

            IAquarium desiredAquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType == nameof(SaltwaterFish))
            {
                fish=new FreshwaterFish(fishName,fishSpecies,price);
                if (desiredAquarium.GetType().Name!=nameof(SaltwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else//fresh water
            {
                fish=new FreshwaterFish(fishName,fishSpecies,price);
                if (desiredAquarium.GetType().Name != nameof(FreshwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }

            desiredAquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);


        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

           aquarium.Feed();
           return string.Format(OutputMessages.FishFed,aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal sumOfDecorations = aquarium.Decorations.Sum(x => x.Price);
            decimal sumOfFishes = aquarium.Fish.Sum(x => x.Price);
            decimal totalPrice = sumOfFishes + sumOfDecorations;

            return string.Format(OutputMessages.AquariumValue, aquariumName,totalPrice);
        }

        public string Report()
        {
           StringBuilder sb=new StringBuilder();
           foreach (var aquarium in aquariums)
           {
               sb.Append(aquarium.GetInfo() + Environment.NewLine);
           }
           return sb.ToString().TrimEnd();
        }
    }
}
