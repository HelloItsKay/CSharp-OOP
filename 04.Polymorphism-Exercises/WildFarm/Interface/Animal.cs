using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WildFarm;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            // FoodEaten = foodEaten;
        }

        public string Name { get; }
        public double Weight { get; private set; }
        public double FoodEaten { get; private set; }


        public virtual void Eat(string foodType, double quantity)
        {
            string currentName = base.GetType().Name;

            if (currentName is "Cat")
            {
                if (foodType is "Vegetable" || foodType is "Meat")
                {
                    FoodEaten = quantity;
                    Weight += quantity * 0.3;
                }

            }

            else if (base.GetType().Name is "Owl" && foodType is "Meat")
            {
                FoodEaten = quantity;
                Weight += quantity * 0.25;
            }
            else if (base.GetType().Name is "Dog" && foodType is "Meat")
            {
                FoodEaten = quantity;
                Weight += quantity * 0.40;
            }
            else if (base.GetType().Name is "Tiger" && foodType is "Meat")
            {
                FoodEaten = quantity;
                Weight += quantity * 1.00;
            }
            else if (base.GetType().Name is "Hen")

            {
                if (foodType is "Vegetable" || foodType is "Meat" || foodType is "Seeds" || foodType is "Fruit")
                {
                    FoodEaten = quantity;
                    Weight += quantity * 0.35;
                }

            }
            else if (base.GetType().Name is "Mouse" && foodType is "Vegetable"|| foodType is "Fruit")
            {
                FoodEaten = quantity;
                Weight += quantity * 0.1;
            }
            else
            {
                Console.WriteLine($"{base.GetType().Name} does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"{base.GetType().Name} [{Name},";
        }

        public virtual void AnimalSound()
        {
            if (base.GetType().Name == "Owl")
            {
                Console.WriteLine($"Hoot Hoot");
            }

            else if (base.GetType().Name == "Hen")
            {
                Console.WriteLine($"Cluck");
            }

            else if (base.GetType().Name == "Mouse")
            {
                Console.WriteLine($"Squeak");
            }

            else if (base.GetType().Name == "Dog")
            {
                Console.WriteLine($"Woof");
            }

            else if (base.GetType().Name == "Cat")
            {
                Console.WriteLine($"Meow");
            }

            else if (base.GetType().Name == "Tiger")
            {
                Console.WriteLine($"ROAR!!!");
            }
        }

    }
}
