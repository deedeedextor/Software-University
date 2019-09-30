namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark parking;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.parking = new SoftPark();

            car = new Car("Audi", "123asd");
        }

        [Test]
        public void TestIfConstructorWorkCorrectly()
        {
            Assert.IsNotNull(this.parking);
        }

        [Test]
        public void TestIfParkCarReturnTheRightMessage()
        {
            var actualResult = this.parking.ParkCar("A1", car);
            var expectedMessage = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(expectedMessage, actualResult);
        }

        [Test]
        public void TestIfParkCarWorksCorrecrtly()
        {
            this.parking.ParkCar("A1", car);

            Assert.AreEqual(car, this.parking.Parking["A1"]);
        }

        [Test]
        public void TestIfParkCarWorksCorrectlyWhenThereIsNoSuchParkingSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.parking.ParkCar("M1", car);
            });
        }

        [Test]
        public void TestIfParkCarWorksCorrectlyWhenParkingSpotIsTaken()
        {
            this.parking.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.parking.ParkCar("A1", new Car("Mercedes", "asd123"));
            });
        }

        [Test]
        public void TestIfParkCarAddsCarWhenItIsAlreadyParked()
        {
            this.parking.ParkCar("A2", car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.parking.ParkCar("A3", car);
            });
        }

        [Test]
        public void TestIfRemoveCarIsWorkingCorrectly()
        {
            this.parking.ParkCar("A2", car);

            this.parking.RemoveCar("A2", car);

            Assert.IsNull(this.parking.Parking["A2"]);
        }

        [Test]
        public void TestIfRemoveCarReturnsTheRightMessage()
        {
            this.parking.ParkCar("A2", car);

            var actualResult = this.parking.RemoveCar("A2", car);
            var expectedMessage = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(expectedMessage, actualResult);
        }

        [Test]
        public void TestRemovingCarFromNonExistingParkingSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.parking.RemoveCar("D3", car);
            });
        }

        [Test]
        public void TestRemovingCarFromEmptyParkingSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.parking.RemoveCar("A1", car);
            });
        }

        [Test]
        public void TestRemovingCarWhenTheCarIsDifferent()
        {
            this.parking.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.parking.RemoveCar("A1", new Car("Mercedes", "asd123"));
            });
        }

    }
}