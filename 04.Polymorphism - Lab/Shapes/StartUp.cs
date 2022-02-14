using System;

namespace Shapes
{
   public class StartUp
    {
        static void Main(string[] args)
        {
             Shape circle=new Circle(4);
             Shape rectangule=new Rectangle(3,5);

             Console.WriteLine(circle.CalculatePerimeter());
             Console.WriteLine(circle.CalculateArea());
             Console.WriteLine(circle.Draw());


             Console.WriteLine(rectangule.CalculatePerimeter());
             Console.WriteLine(rectangule.CalculateArea());
             Console.WriteLine(rectangule.Draw());


             
        }
    }
}
