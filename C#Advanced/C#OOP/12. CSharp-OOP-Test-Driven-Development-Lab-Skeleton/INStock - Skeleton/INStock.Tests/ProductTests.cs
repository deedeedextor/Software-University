namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        private IProduct product;

        [SetUp]
        public void SetUp()
        {
            this.product = new Product("SSD", 12.34m, 2);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectValues()
        {
            Assert.AreEqual("SSD", this.product.Label);
            Assert.AreEqual(12.34m, this.product.Price);
            Assert.AreEqual(2, this.product.Quantity);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenLabelIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                IProduct product = new Product("", 12.34m, 2);
            });
        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionWhenPriceIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IProduct product = new Product("SSD", -12.34m, 2);
            });
        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionWhenQuantityIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IProduct product = new Product("SSD", 12.34m, -1);
            });
        }

        [Test]
        public void CompareToMethodShouldReturnLabelWithGreaterAsciiCode()
        {
            var greaterProductLabel = "Zoom";
            var greaterProductPrice = 34.12m;
            var greaterProductQuantity = 2;

            var smallerProductLabel = "Do";
            var smallerProductPrice = 12.34m;
            var smallerProductQuantity = 4;

            IProduct greaterProduct = new Product(greaterProductLabel, greaterProductPrice,
                greaterProductQuantity);

            IProduct smallerProduct = new Product(smallerProductLabel, smallerProductPrice,
                smallerProductQuantity);

            var ActualResult = greaterProduct.CompareTo(smallerProduct);
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, ActualResult);
        }
    }
}