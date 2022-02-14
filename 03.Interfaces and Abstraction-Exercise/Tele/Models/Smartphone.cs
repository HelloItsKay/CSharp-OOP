using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tele.Exeptions;
using Tele.Interfaces;

namespace Tele.Models
{
    public class Smartphone : ICallable, IBrowsable
    {

        public string Browsing(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidUrlExeption();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberExeption();
            }

            return $"Calling... {phoneNumber}";
        }


    }
}
