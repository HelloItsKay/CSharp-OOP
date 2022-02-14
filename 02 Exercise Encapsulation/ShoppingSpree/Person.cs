using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {

        private string _name;
        private decimal _money;
        private List<Product> products;


        public Person(string name,decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

      

        public string Name
        {
            get => _name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value,"Name cannot be empty "); 

                _name = value;
            }
        }


        public decimal Money
        {
            get => _money;
            private set
            {
               Validator.ThrowIfNumberIsNegative(value,"Money cannot be negative");

                _money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if (product.Cost>Money)
            {
                throw  new InvalidOperationException($"{Name} can't afford {product.Name}");

            }

            products.Add(product);
            Money -= product.Cost;
        }


        public override string ToString()
        {
            if (products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            return $"{Name} - {string.Join(", ", products.Select(n => n.Name))}";
        }
    }
}
