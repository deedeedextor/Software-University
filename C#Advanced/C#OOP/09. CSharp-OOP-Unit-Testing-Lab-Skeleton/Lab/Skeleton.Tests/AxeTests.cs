using FluentAssertions;
using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAtack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(AxeAtack, AxeDurability);
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(0));
            axe.DurabilityPoints.Should().Be(0);
        }

        [Test]
        public void BrokenAxeCanAttack()
        {
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), 
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
