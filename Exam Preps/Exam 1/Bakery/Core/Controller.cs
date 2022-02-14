using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<BakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddFood(string type, string name, decimal price)
        {

            if (type is "Bread")
            {
                bakedFoods.Add(new Bread(name, price));
            }

            if (type is "Cake")
            {
                bakedFoods.Add(new Cake(name, price));
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {

            if (type is "Water")
            {
                drinks.Add(new Water(name, portion, brand));
            }

            if (type is "Tea")
            {
                drinks.Add(new Tea(name, portion, brand));
            }

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type is "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }

            if (type is "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return $"Added table number {tableNumber} in the bakery";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(table => !table.IsReserved && table.Capacity >= numberOfPeople);
            if (table is null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table is null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
                if (food is null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table is null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IDrink drink = drinks.FirstOrDefault(f => f.Name == drinkName && f.Brand == drinkBrand);
                if (drink is null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();
            return $"Table: {tableNumber}\r\n" +
                   $"Bill: {bill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            string result = "";
            List<ITable> freeTables = tables.Where(table => !table.IsReserved).ToList();

            foreach (var freeTable in freeTables)
            {
                result += freeTable.GetFreeTableInfo() + Environment.NewLine;
            }

            
            return result.TrimEnd(); 
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        } 
    }
}
