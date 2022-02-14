namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    public class RobotsTests
    {

        [SetUp]
        public void SetUp()
        {
          var robotManager = new RobotManager(2);
            var robot = new Robot("Pesho", 10);
        }

        [Test]
        public void Constructor_Initialiser()
        {
            int capacity = 100;
            var robotManager = new RobotManager(capacity);

            int expectedCapacity = 100;

            int actualCapacity = robotManager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void Capacity_ThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-10));
        }

        [Test]
        public void Add_ThrowExceptionWhenAddSameName()
        {
            var robotManager = new RobotManager(5);
            var robot = new Robot("Pesho", 10);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void AddRobotThrowException_CapacityIsInvalid()
        {
            var robotManager = new RobotManager(0);
            var robot = new Robot("Pesho", 10);


            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void Add_Valid()
        {
            var robotManager = new RobotManager(3);
            var robot = new Robot("Pehso", 10);

            robotManager.Add(robot);

            var expectedCount = 1;
            var actualCount = robotManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Remove_ThrowExceptionWhenIsNull()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Pehso"));
        }

        [Test]
        public void Remove_RemoveRobotWhenNameIsCorrect()
        {
            var robotManager = new RobotManager(2);
            var robot = new Robot("Pesho", 10);

            robotManager.Add(robot);
            robotManager.Remove("Pesho");

            var expexted = 0;
            var actual = robotManager.Count;

            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void Work_ThrowException_NameNotFound()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Null", "Null", 5));
        }

        [Test]
        public void Work_ShouldThrowException_BaterryIsLow()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("Pehso", 11);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Pesho", "Job", 10));
        }

        [Test]
        public void Work_DecreaseBattery()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("Pesho", 10);

            robotManager.Add(robot);
            robotManager.Work("Pesho", "Null", 5);

            var expectedBattery = 5;
            var actualBattery = robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void BatteryLowThenExpected_ThrowException()
        {
            var robotManager = new RobotManager(100);
            var robot = new Robot("Pehso", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Pehso", "RobDoJivot", 666));
        }

        [Test]
        public void Charge_RobotIsNotFound()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Pehso"));
        }

        [Test]
        public void Charge_Succsess()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("Pesho", 10);

            robot.Battery = 5;

            robotManager.Add(robot);
            robotManager.Charge("Pesho");

            var expectedBattery = 10;
            var actualBattery = robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }
    }
}