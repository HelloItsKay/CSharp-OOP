using System;
using Tele.Exeptions;
using Tele.Interfaces;
using Tele.Models;

namespace Tele
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] url = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < numbers.Length; i++)
            {
                string phoneNumber = numbers[i];

                try
                {
                    Console.WriteLine(phoneNumber.Length == 7
                        ? stationaryPhone.Call(phoneNumber)
                        : smartphone.Call(phoneNumber));
                }
                catch (InvalidPhoneNumberExeption e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            for (int i = 0; i < url.Length; i++)
            {
                string urls = url[i];
                try
                {
                    Console.WriteLine(smartphone.Browsing(urls));
                }
                catch (InvalidUrlExeption e)
                {
                    Console.WriteLine(e.Message);

                }


            }


        }
    }
}
