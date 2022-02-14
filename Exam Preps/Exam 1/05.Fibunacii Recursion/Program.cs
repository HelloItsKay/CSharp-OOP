using System;

namespace _05.Fibunacii_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" #" + Fibonacci(number));
        }

        public static int Fibonacci(int number)
        {
            if (number <= 2)
            {
                return 1;
            }

            int currentNumber = number - 1;
            int currentNumber2 = number - 2;
            int currentNumber3 = Fibonacci(currentNumber) + Fibonacci(currentNumber2);

            return Fibonacci(currentNumber) + Fibonacci(currentNumber2);
        }
    }
}
