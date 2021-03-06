using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Fish
{
    public abstract class Fish:IFish
    {
        private string name;
        private string species;
       // private int size;
        private decimal price;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }

                name = value;
                // All fish names are Unique
            }
        }
        public string Species 
        {
            get => species;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }

                species = value;
                
            }
        }
        public int Size { get; protected set; }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                price = value;
            }
        }


        protected Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;

        }

        public abstract void Eat();

    }
}
