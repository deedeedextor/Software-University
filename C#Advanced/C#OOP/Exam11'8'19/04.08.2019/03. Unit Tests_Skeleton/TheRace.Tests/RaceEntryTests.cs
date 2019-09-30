using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitRider rider;
        private RaceEntry race;
        private UnitMotorcycle motorcycle;

        [SetUp]
        public void Setup()
        {
            this.motorcycle = new UnitMotorcycle("Suzuki", 100, 60);
            this.rider = new UnitRider("Ivan", motorcycle);

            this.race = new RaceEntry();
        }

        [Test]
        public void TestIfConstructorInitializeDictionary()
        {
            Assert.IsNotNull(this.race);
        }

        [Test]
        public void TestIfUnitRiderConstructorWorksCorrectly()
        {
            string expectedNameRider = "Ivan";
            var expectedMotorcycle = motorcycle;

            Assert.AreEqual(expectedNameRider, rider.Name);
            Assert.AreEqual(expectedMotorcycle, motorcycle);
        }

        [Test]
        public void TestNameRiderProperty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                rider = new UnitRider(null, motorcycle);
            });
        }

        [Test]
        public void TestIfAddRiderWorksCorrectly()
        {
            this.race.AddRider(rider);

            Assert.AreEqual(1, this.race.Counter);
        }

        [Test]
        public void TestIfAddRiderAddsNullRider()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.AddRider(null);
            });
        }

        [Test]
        public void TestIfAddRiderReturnsCorrectMessage()
        {
            var actualResult = this.race.AddRider(rider);
            var expectedMessage = "Rider Ivan added in race.";

            Assert.AreEqual(expectedMessage, actualResult);
        }

        [Test]
        public void TestIfAddRiderAddsTheSameRider()
        {
            this.race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.AddRider(rider);
            });
        }

        [Test]
        public void TestIfAverageHorsePowerWorksCorrectly()
        {
            this.race.AddRider(rider);

            motorcycle = new UnitMotorcycle("Qmaha", 150, 80);
            rider = new UnitRider("Pesho", motorcycle);

            this.race.AddRider(rider);

            int expectedHorsePower = 125;

            Assert.AreEqual(expectedHorsePower, this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void TestIfAverageHorsePowerThrowsExceptionIfRidersAreLessThan2()
        {
            this.race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.CalculateAverageHorsePower();
            });
        }
    }
}