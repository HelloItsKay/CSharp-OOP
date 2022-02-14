using System.Linq;
using Tele.Exeptions;
using Tele.Interfaces;

namespace Tele.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberExeption();
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}
