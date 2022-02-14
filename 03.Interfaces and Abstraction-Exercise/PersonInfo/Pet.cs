using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace PersonInfo
{
   public class Pet:IPet,IBirthdays
    {
        public Pet(string name, string birthdate)
        {
            Name = birthdate;
            Birthdate = birthdate;
        }
        public string Name { get; set; }

        public string Birthdate { get; }
    }
}
