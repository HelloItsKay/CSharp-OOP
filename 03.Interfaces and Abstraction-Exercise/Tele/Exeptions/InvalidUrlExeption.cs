using System;
using System.Collections.Generic;
using System.Text;

namespace Tele.Exeptions
{
  public  class InvalidUrlExeption:Exception
    {
        private const  string Invalid_URL_exeption_message="Invalid URL!";
        public InvalidUrlExeption():base(Invalid_URL_exeption_message)
        {
            
        }
    }
}
