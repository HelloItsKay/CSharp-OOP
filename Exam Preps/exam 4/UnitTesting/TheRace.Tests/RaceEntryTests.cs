using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry driver;

        [SetUp]
        public void Setup()
        {
            driver=new RaceEntry();
        }

        [Test]
        public void Add_Driver_ThrowsNullException()
        {
            Assert.Throws<InvalidOperationException>((() => driver.AddDriver(null)));
        }

        [Test]
        public void Add_Driver_IsAlreadyIin()
        {
            driver.AddDriver(new UnitDriver("Pesho", new UnitCar("Teesla", 420, 0)));
            Assert.Throws<InvalidOperationException>(()=> driver.AddDriver(new UnitDriver("Pesho", new UnitCar("Teesla", 420, 0))));
        }

        [Test]
        public void Add_Sucess()
        {
            driver.AddDriver((new UnitDriver("Pesho", new UnitCar("Teesla", 420, 0))));
            Assert.AreEqual(1,driver.Counter);
        }

        [Test]
        public void Add_Driver_ReturnSuccsess()
        {
            var actual = driver.AddDriver(new UnitDriver("Pesho", new UnitCar("Teesla", 420, 0)));
            var expected = $"Driver Pesho added in race.";
            Assert.AreEqual(expected,actual);
        }


        [Test]
        public void Calculate_ThrowsInvalidArgumentException()
        {
            driver.AddDriver(new UnitDriver("Pesho", new UnitCar("Teesla", 420, 0)));
            Assert.Throws<InvalidOperationException>(() => driver.CalculateAverageHorsePower());

        }


        [Test]
        public void Calculate_SuccessReturnsCorrectValue()
        {
            driver.AddDriver(new UnitDriver("Pesho", new UnitCar("Teesla", 100, 0)));
            driver.AddDriver(new UnitDriver("Gosho", new UnitCar("Tesla", 100, 0)));
            driver.AddDriver(new UnitDriver("Ivan", new UnitCar("Tesla", 100, 0)));

            double actual = driver.CalculateAverageHorsePower();
            double expected = 100;
            Assert.AreEqual(expected,actual);

        }


    }
}
