using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Items
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> listofItems;
  
        protected Bag(int capacity)
        {
            Capacity = capacity;
            listofItems = new List<Item>();
            Items = new ReadOnlyCollection<Item>(listofItems);
        }
        
        public int Capacity { get; set; }
        
        public int Load => Items.Sum(x => x.Weight);
        public IReadOnlyCollection<Item> Items { get; }


        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            listofItems.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item desiredItem = Items.FirstOrDefault(x => x.GetType().Name == name);

            if (desiredItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            listofItems.Remove(desiredItem);

            return desiredItem;

        }
    }
}
