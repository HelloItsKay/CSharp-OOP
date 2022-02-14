using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
   public class DriverRepository : IRepository<IDriver>
   {
       private readonly List<IDriver> drivers;

       public DriverRepository()
       {
           drivers = new List<IDriver>();
       }

        public IDriver GetByName(string name)
        {
            return drivers.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return drivers.ToList();
        }

        public void Add(IDriver model)
        {
            drivers.Add(model);
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model);
        }
    }
}
