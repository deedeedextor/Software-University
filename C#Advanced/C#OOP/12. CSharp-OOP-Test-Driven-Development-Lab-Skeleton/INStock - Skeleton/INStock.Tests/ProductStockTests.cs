namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    public class ProductStockTests
    {
        private IProductStock productStock;
        private IProduct product1;
        private IProduct product2;
        private IProduct product3;
        private IProduct product4;
        private IProduct product5;

        [SetUp]
        public void SetUp()
        {
            this.product1 = new Product("SSD", 12.34m, 2);
            this.product2 = new Product("DDS", 12.32m, 1);
            this.product3 = new Product("SSS", 11.15m, 4);
            this.product4 = new Product("DDD", 5.80m, 5);
            this.product5 = new Product("SDD", 7.85m, 6);
            this.productStock = new ProductStock();
        }

        [Test]
        public void ConstructorShoulInitializeTheArray()
        {
            var expectedValue = 4;
            var actualValue = this.productStock.Capacity;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddShouldAddSuccessfully()
        {
            this.productStock.Add(product1);

            Assert.AreEqual(1, this.productStock.Count);
        }

        [Test]
        public void AddShouldResizeWhenCountIsEqualToArrayLength()
        {
            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            var expectedValue = 8;
            var actualValue = this.productStock.Capacity;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddShouldShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.Add(null);
            });
        }

        [Test]
        public void SetInvalidIndexShouldReturnIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock[this.productStock.Capacity + 2] = product1;
            });
        }

        [Test]
        public void SetValidIndexShouldSetSuccessfully()
        {
            this.productStock[0] = product1;

            Assert.AreSame(product1, productStock[0]);
        }

        [Test]
        public void GetValidIndexShouldReturnValue()
        {
            this.productStock.Add(product1);
            var product = this.productStock[0];

            Assert.AreSame(product1, product);
        }

        [Test]
        public void GetInvalidIndexShouldThrowOutOfRangeException()
        {
            this.productStock.Add(product1);
            IProduct product = null;

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                product = this.productStock[2];
            });
        }

        [Test]
        public void RemoveShouldRemoveSuccessfullyProduct()
        {
            this.productStock.Add(product1);
            this.productStock.Remove(product1);

            Assert.AreEqual(0, this.productStock.Count);
        }

        [Test]
        public void RemoveShouldReorderCorrectly()
        {
            var products = new []
            {
                 new Product("SSD", 12.34m, 2),
                 new Product("DDS", 12.32m, 1),
                 new Product("SSS", 11.15m, 4),
                 new Product("DDD", 5.80m, 5),
                 new Product("SDD", 7.85m, 6),
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }

            this.productStock.Remove(products[2]);

            for (int i = 2; i < this.productStock.Count; i++)
            {
                Assert.AreEqual(products[i + 1], this.productStock[i]);
            }
        }

        [Test]
        public void RemoveShouldShrinkWhenLengthIsHalfEmpty()
        {
            var products = new[]
            {
                 new Product("SSD", 12.34m, 2),
                 new Product("DDS", 12.32m, 1),
                 new Product("SSS", 11.15m, 4),
                 new Product("DDD", 5.80m, 5),
                 new Product("SDD", 7.85m, 6),
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }

            this.productStock.Remove(products[3]);

            var expectedValue = 4;
            var actualValue = this.productStock.Capacity;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void RemoveShouldReturnFalseWhenProductIsNotFound()
        {
            Assert.AreEqual(false, this.productStock.Remove(product1));
        }

    }
}
