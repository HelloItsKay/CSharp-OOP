using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Cars
{
  public  class Seat:ICar
    {
        public Seat(string model, string color)
        {
            Color = color;
            Model = model;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} Tesla {Model}";
        }
    }
}
