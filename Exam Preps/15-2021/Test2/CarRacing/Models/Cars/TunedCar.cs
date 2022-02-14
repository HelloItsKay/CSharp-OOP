using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
  public  class TunedCar : Car
    {
        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, 65,
            7.5)
        {

        }
        public override void Drive()
        {
            base.Drive();
            double threePercent = HorsePower * 3 / 100;
            HorsePower -= (int)threePercent;
        }
    }
}
