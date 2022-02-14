using System;
using System.Collections.Generic;

namespace SortArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 2, 9, 4, 3, 5, 1, 7 ,6,8};


            List<int> numbers = new List<int>() { 2,4,6,8,9 };
          //  numbers.RemoveAll(numbers => numbers % 2 == 0);

            var temp=new List<int>(numbers);
            foreach (var i in temp)
            {
                if (i%2==0)
                {
                    numbers.Remove(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));


            for (int i = 0; i < intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    int firstNumber = intArray[i];
                    int secondNumber = intArray[j];

                    if (firstNumber < secondNumber)
                    {
                        intArray[i] = secondNumber;
                        intArray[j] = firstNumber;
                    }
                }
            }
            Console.WriteLine($"Array sort in asscending order:\n{string.Join(" ", intArray)}");

        }
    }
}