using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
   public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length,double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;

        }
        public double Length
        {
            get => length;
            private set
            {
              ThrowInvalidSide(value,nameof(Length));

                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
               ThrowInvalidSide(value,nameof(Width));

                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
               ThrowInvalidSide(value,nameof(Height));

                height = value;
            }
        }

        public double CalculateVolume()
        {
            return Width * Length * Height;
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double CalculateSurfaceArea()
        {
            return (2 * Length * Width + 2 * Length * Height + 2 * Width * Height);   
        }


        private void ThrowInvalidSide(double value, string side)
        {
            if (value<=0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }

    }
}
