// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 


using System.Collections.Generic;
using System.Linq;
using FestivalManager.Entities;
using NUnit.Framework.Constraints;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage = null;
        private List<Performer> performers;

        [SetUp]
        public void StartUp()
        {
            stage = new Stage();
            performers = new List<Performer>();
        }

        //-----------------------------------Performer---------------------------------------------
        [Test]
        public void Add_Performer_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Pesho", "Peshov", 17)));
        }

        [Test]

        public void Add_Performer_Null()
        {
            Performer performer = null;
            // stage.AddPerformer(performer);
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));


        }

        [Test]
        public void Add_Performer_Sucssess()
        {
            var expectedCount = 1;
            stage.AddPerformer(new Performer("Pesho", "Peshov", 18));

            Assert.AreEqual(expectedCount, stage.Performers.Count);
        }

        //-----------------------------------Songs------------------------------------------------------
        [Test]
        public void Add_Songs_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("Pesho", new TimeSpan(0, 0, 30))));
        }

        [Test]
        public void Add_Songs_ThrowsNullException()
        {
            Song song = null;
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
        }

        [Test]
        public void AddSongToPerformer_SongNameandPerformarNameMustNOtBeNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => stage.AddSongToPerformer(null,"Pesho"));
            Assert.Throws(typeof(ArgumentNullException), () => stage.AddSongToPerformer("pesho",null));
        }

        [Test]
        public void Add_SongToPerformer_Success()
        {
            var song = new Song("asd",new TimeSpan(0,1,23));
            var  performer=new Performer("afa","dasd",22);

            stage.AddPerformer(performer);
            stage.AddSong(song);

            stage.AddSongToPerformer("asd", "afa dasd");

            Assert.That(performer.SongList.Count ==1);
            Assert.That(performer.SongList.FirstOrDefault().Equals(song));
        }
        [Test]
        public void Stage_Play_ReturnsRIghtNumbers()
        {
            var song = new Song("asd", new TimeSpan(0, 1, 23));
            var performer = new Performer("afa", "dasd", 22);

            stage.AddPerformer(performer);
            stage.AddSong(song);

            stage.AddSongToPerformer("asd", "afa dasd");

            Assert.That(performer.SongList.Count == 1);
            Assert.That(performer.SongList.FirstOrDefault().Equals(song));

            string result = stage.Play();
            Assert.That(result == "1 performers played 1 songs");
        }
        [Test]
        public void Add_Song_NotExisting()
        {
            var performer = new Performer("afa", "dasd", 22);
            stage.AddPerformer(performer);
        

            Assert.Throws(typeof(ArgumentException), (() => stage.AddSongToPerformer("asd", "afa dasd")));
        }

        [Test]
        public void Add_SongToPerformer_DontExist()
        {
            var song = new Song("asd", new TimeSpan(0, 1, 23));
            stage.AddSong(song);

            Assert.Throws(typeof(ArgumentException), (() => stage.AddSongToPerformer("asd", "dsds")));
        }

    }
}




