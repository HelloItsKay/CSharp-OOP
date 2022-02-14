using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01._Job_Interview_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            {
                9,8,7,6,// работи само с числа отговарящи на индекс... ;
            };
            SortMyList(numbers);
            Console.WriteLine(string.Join(" ", numbers));
            
        }

        private static void SortMyList(List<int> numbers)
        {
            bool isDone = false;//
            while (isDone != true)
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (isDone)
                    {
                        break;
                    }

                    int firstNumberTemp = numbers[i];
                    int secondNumberTemp = numbers[i + 1];

                    if (firstNumberTemp > secondNumberTemp)
                    {
                        numbers[i] = secondNumberTemp;
                        numbers[i + 1] = firstNumberTemp;
                    }

                    int count = 0;
                    foreach (var number in numbers)
                    {
                        if (number == numbers.IndexOf(number))
                        {
                            count++;
                        }

                        if (count == numbers.Count)
                        { 
                            isDone = true;
                        }
                    }
                    
                }
              
            }

           
        }
    }
}