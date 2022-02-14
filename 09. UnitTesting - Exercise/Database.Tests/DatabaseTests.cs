using System;
using System.Linq;
using NUnit.Framework;




namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void Ctor_ThrowExeptionWhenCountIsExceeded()
        {
            Assert.Throws<InvalidOperationException>((() => database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)));
        }

        [Test]
        public void Ctor_AddValidItemsInToDo()
        {

            var elements = new int[] { 1, 2, 3 };
            database = new Database.Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));


        }
        [Test]
        public void Add_IncrementCountWhenAddIsValid()
        {
            var n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            Assert.That(database.Count, Is.EqualTo(n));
        }
        
        [Test]
        public void Add_ThrowExeptionWhenCapacityExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>((() => database.Add(17)));
        }

        [Test]
        public void Remove_DecreaseDbCapacity()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            var expectedRemoveCount = 2;
            Assert.That(database.Count,Is.EqualTo(expectedRemoveCount));
        }

        [Test]
        public void Remove_ThrowsExeptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>((() => database.Remove()));
        }

        [Test]
        public void Remove_RemovesElementFromDb()
        {
            var n = 3;
            var lastElement = 3;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            int [] elements = database.Fetch();
            Assert.IsFalse(elements.Contains(lastElement));
        }
        [Test]
        public void Fetch_ReturndsDbCopyNotreference()
        {
            database.Add(1);
            database.Add(2);
            var firstCopy = database.Fetch();
            database.Add(3);
            var secondCoptu = database.Fetch();
            Assert.That(firstCopy,Is.Not.EqualTo(secondCoptu));
        }

        [Test]
        public void Ctor_ReturnsZeroWhenDbIsEmpty()
        {
            Assert.That(database.Count,Is.EqualTo(0));
        }
    }
}