using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = ReadConsole();
            string[] url = ReadConsole();
            ICall calling = null;
            foreach (var item in numbers)
            {
                if (item.Length == 10)
                {
                    calling = new Smartphone();
                    calling.Calling(item);
                }
                else if (item.Length == 7)
                {
                    calling = new StationaryPhone();
                    calling.Calling(item);
                }
            }
            foreach (var item in url)
            {
                IBrowse browse = new Smartphone();
                browse.Browsing(item);
            }
        }
        private static string[] ReadConsole() => Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries);
    }
}

