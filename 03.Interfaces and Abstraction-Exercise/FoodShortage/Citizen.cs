﻿using System;
using System.Collections.Generic;
using System.Text;
using PersonInfo;

namespace FoodShortage
{
    class Citizen : IPerson, IBirthdays, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            Id = id;
            Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; private set; }
        public string Id { get; private set; }
        public int Food { get; private set; }


        public void BuyFood()
        {
            Food += 10;
        }


    }
}
