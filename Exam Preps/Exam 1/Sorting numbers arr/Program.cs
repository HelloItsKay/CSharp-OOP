using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Sorting_numbers_arr
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 9, 4, 3, 5, 1, 7, 6, 8 };
            SortMyList(numbers);
            RemoveEvenNumbersFromList(numbers);
            Console.WriteLine($"Your sorted list is:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.Write($"Input fibunacii number`s index: ");
            int fibunaciInputNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"The fibunacii number on index {fibunaciInputNumber} is {FibunaciiNumberIndex(fibunaciInputNumber)}.");
           
        }

        public static void SortMyList(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    int firstNumber = numbers[i];
                    int secondNumber = numbers[j];
                    //
                    if (secondNumber < firstNumber)
                    {
                        numbers[j] = firstNumber;
                        numbers[i] = secondNumber;
                    }
                }
            }
        }

        public static void RemoveEvenNumbersFromList(List<int> numbers)
        {
            //List<int> tempList = new List<int>(numbers);

            //foreach (var number in tempList)
            //{
            //    if (number % 2 == 0)
            //    {
            //        numbers.Remove(number);
            //    }

            //    // numbers.RemoveAll(numbers=>numbers%2==0);
            //}
           
        }



        public static int FibunaciiNumberIndex(BigInteger number)
        {
           
            if (number<=2)
            {
                return 1;
            }

           Console.WriteLine(FibunaciiNumberIndex(number - 1) + FibunaciiNumberIndex(number - 2));
            return FibunaciiNumberIndex(number - 1) + FibunaciiNumberIndex(number-2);
        }
    }
}