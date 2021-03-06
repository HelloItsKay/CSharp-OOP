using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        private const string MESSAGE = "Calling... {0}";
        private const string INVALID_URL = "Invalid URL!";
        private const string BROWSE_MESSAGE = "Browsing: {0}!";

        public void Browsing(string url)
        {
            if (Validator.IsUrlIsValid(url))
            {
                Console.WriteLine(string.Format(BROWSE_MESSAGE, url));
            }
            else
            {
                Console.WriteLine(INVALID_URL);
            }
        }

        public void Calling(string number)
        {
            if (Validator.IsNumberIsValid(number))
            {
                Console.WriteLine(string.Format(MESSAGE, number));
            }
            else
            {
                Console.WriteLine(Validator.INVALID_NUMBER);
            }
        }
    }
}
