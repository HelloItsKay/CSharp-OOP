﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
   public class DecorationRepository:IRepository<IDecoration>
   {
       private List<IDecoration> decorations;


       public DecorationRepository()
       {
           decorations=new List<IDecoration>();
       }

       public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();
        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public bool Remove(IDecoration model)
        {
           return decorations.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return decorations.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}
