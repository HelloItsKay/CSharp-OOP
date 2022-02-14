using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();
            Queue<Animal> eatAnimals = new Queue<Animal>();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var type = input[0];

                if (type is "End")
                {
                    break;
                }
                var name = input[1];
                var weight = double.Parse(input[2]);



                if (type is "Cat" || type is "Tiger")
                {
                    string livingRegion = input[3];
                    string breed = input[4];
                    if (type is "Cat")
                    {
                        animals.Add(new Cat(name, weight, livingRegion, breed));
                       // eatAnimals.Enqueue(new Cat(name, weight, livingRegion, breed));
                        animals.Last().AnimalSound();
                       // eatAnimals.Peek().AnimalSound();
                    }
                    else
                    {
                        animals.Add(new Tiger(name, weight, livingRegion, breed));
                        animals.Last().AnimalSound();

                    }

                }
                else if (type is "Owl"||type is "Hen")
                {
                    double wingSize = double.Parse(input[3]);

                    if (type is "Owl")
                    {
                        animals.Add(new Owl(name,weight,wingSize));
                        animals.Last().AnimalSound();
                    }
                    else
                    {

                        animals.Add(new Hen(name, weight, wingSize));
                        animals.Last().AnimalSound();
                    }

                }
                else if ( type is "Dog" || type is "Mouse")
                {
                    string livingRegion = input[3];
                    if (type is "Dog")
                    {
                        animals.Add(new Dog(name, weight, livingRegion));
                        animals.Last().AnimalSound();
                    }
                    else
                    {
                        animals.Add(new Mouse(name, weight, livingRegion));
                        animals.Last().AnimalSound();
                    }
                }

                var line = Console.ReadLine().Split();
                string foodType = line[0];
                int foodQuantity = int.Parse(line[1]);

                // eatAnimals.Peek().Eat(foodType, foodQuantity);
                animals.Last().Eat(foodType, foodQuantity);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }

        }
    }
}
