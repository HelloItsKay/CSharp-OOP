using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        [Test]

        public void Ctor_InitialiseCorrectly()
        {
            var name = "aname";
            int cap = 1;
            Aquarium aquarium = new Aquarium(name, cap);

            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, cap);

        }

        [Test]

        public void SetName()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 1));
        }


        [Test]
        public void Caoacity_ThrowArgException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("aaa", -1));
        }


        [Test]
        public void Count_Test()
        {
            Aquarium aquarium = new Aquarium("name", 1);
            aquarium.Add(new Fish("aaa"));
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void Add_throwException()
        {

            Aquarium aquatium = new Aquarium("test", 0);
            Assert.Throws<InvalidOperationException>(() => aquatium.Add(new Fish("fish")));
        }
        [Test]
        public void Add_Sucsess()
        {

            Aquarium aquatium = new Aquarium("test", 1);
            aquatium.Add(new Fish("fish"));
            Assert.AreEqual(1, aquatium.Count);
        }

        [Test]
        public void Remove_Sucsess()
        {

            Aquarium aquatium = new Aquarium("test", 1);
            aquatium.Add(new Fish("fish"));
            aquatium.RemoveFish("fish");
            Assert.AreEqual(0, aquatium.Count);
        }

        [Test]
        public void Remove_ThrowException()
        {

            Aquarium aquatium = new Aquarium("test", 1);
            aquatium.Add(new Fish("fish"));

            Assert.Throws<InvalidOperationException>(()=>aquatium.RemoveFish("Test"));
        }

        [Test]
        public void FishSell_Sucsess()
        {

            Aquarium aquatium = new Aquarium("test", 1);
           aquatium.Add(new Fish("fish"));

           Fish fish = aquatium.SellFish("fish");
           Assert.AreEqual(fish.Name,"fish");
           Assert.AreEqual(fish.Available,false);
        }

        [Test]
        public void FishSell_ThrowException()
        {

            Aquarium aquatium = new Aquarium("test", 1);

            Assert.Throws<InvalidOperationException>(() => aquatium.SellFish(null));
        }
        [Test]
        public void Report_Test()
        {

            Aquarium aquatium = new Aquarium("test", 3);
            aquatium.Add(new Fish("test1"));
            string report = $"Fish available at {aquatium.Name}: {"test1"}";
          string test=  aquatium.Report();

            Assert.AreEqual(test,report);


        }

    }
}
