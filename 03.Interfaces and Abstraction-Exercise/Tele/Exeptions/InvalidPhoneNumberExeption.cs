using System;
using System.Collections.Generic;
using System.Text;

namespace Tele.Exeptions
{
    public class InvalidPhoneNumberExeption : Exception
    {

        private const string Invalid_Number_exeption_message = "Invalid number!";

        public InvalidPhoneNumberExeption()
            : base(Invalid_Number_exeption_message)
        {

        }
    }
}
