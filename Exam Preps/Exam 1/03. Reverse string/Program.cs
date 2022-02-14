using System;

namespace _03._Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "I love SoftUni";
            string reserve = "";


            int lentght = input.Length - 1;
            while (lentght>=0)
            {
                reserve = reserve + input[lentght];
                lentght--;
            }

            Console.WriteLine(reserve);
        }
    }
}
