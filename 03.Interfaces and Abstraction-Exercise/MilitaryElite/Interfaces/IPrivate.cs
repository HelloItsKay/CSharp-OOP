using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IPrivate : ISoldier
    {
        double Salary { get; }
    }
}
