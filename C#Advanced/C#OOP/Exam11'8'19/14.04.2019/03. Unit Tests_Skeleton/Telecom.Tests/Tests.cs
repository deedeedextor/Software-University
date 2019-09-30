namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Samsung", "A3");
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedMake = "Samsung";
            string expectedModel = "A3";

            Assert.AreEqual(expectedMake, this.phone.Make);
            Assert.AreEqual(expectedModel, this.phone.Model);
        }

        [Test]
        public void TestMakeProperty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.phone = new Phone(null, "A3");
            });
        }

        [Test]
        public void TestModelProperty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.phone = new Phone("Samsung", "");
            });
        }

        [Test]
        public void TestIfAddContactWorksCorrectly()
        {
            int expectedCount = 1;

            this.phone.AddContact("Ivan", "123");

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void TestIfAddContactDoesNotAddExistingName()
        {
            this.phone.AddContact("Ivan", "123");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.AddContact("Ivan", "567");
            });
        }

        [Test]
        public void TestIfCallingWorksCorrectly()
        {
            this.phone.AddContact("Ivan", "123");

            Assert.AreEqual("Calling Ivan - 123...",this.phone.Call("Ivan"));
        }

        [Test]
        public void TestIfCallingToNonExistingNumber()
        {
            this.phone.AddContact("Ivan", "123");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call("Pesho");
            });
        }

    }
}