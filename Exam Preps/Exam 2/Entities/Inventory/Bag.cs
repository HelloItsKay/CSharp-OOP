using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        public int Capacity { get; set; }
        public int Load => Items.Sum(i => i.Weight);
        private readonly IList<Item> internalItems;
        public IReadOnlyCollection<Item> Items { get; }


        public Bag(int capacity)    
        {
            Capacity = capacity;
            internalItems=new List<Item>();
            Items=new ReadOnlyCollection<Item>(internalItems);
        }

        public void AddItem(Item item)
        {
            if (Load+item.Weight>Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            internalItems.Add(item);
        }

        public Item GetItem(string name)
        {
            
            if (Items.Count is 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item resuItem = Items.FirstOrDefault(i => i.GetType().Name == name);
            if (resuItem is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag,name));
            }
            
            internalItems.Remove(resuItem);

            return resuItem;
        }
    }
}
