using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        private Item itemTaken;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("me", "1");

        }
      /// <summary>
      /// Tests
      /// </summary>
      
      //--------- Add----------------------------------------------------- 
        [Test]
        public void Add_CellDoesNotExsistThrowExeption()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("go nqma", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }
        [Test]
        public void Add_CellIsAlreadyTakenException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A1", item);
                vault.AddItem("A1", new Item("pesho", "3"));
            });
            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void Add_ItemIsAlreadyInTheCellThrowException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A1", item);
                vault.AddItem("A2", item);
            });
            Assert.AreEqual(ex.Message, "Item is already in cell!");

        }
        [Test]
        public void Add_ItemIsSucsessfulyShouldReturnMessage()
        {
            string result = vault.AddItem("A1", item);
            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        // --------------Remove-----------------------------------------

        [Test]
        public void Remove_CellDoesNotExsistThrowExeption()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("go nqma", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void Remove_ItemInThatCellDoesNotExistThrowsException()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A1", item);
                vault.RemoveItem("A1", new Item("Pesho", "nesushtestvuvashtoId"));
            });

            Assert.AreEqual(ex.Message, $"Item in that cell doesn't exists!");
        }

        [Test]
        public void Remove_SucsesslyReturnMessage()
        {
            vault.AddItem("A1", item);
            string result = vault.RemoveItem("A1", item);
            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
    }
}