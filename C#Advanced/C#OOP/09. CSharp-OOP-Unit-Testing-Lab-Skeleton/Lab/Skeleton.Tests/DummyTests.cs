namespace Skeleton.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestFixture]
    public class DummyTests
    {
        private const int dummyHealth = 10;
        private const int dummyExperience = 10;

        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(dummyHealth, dummyExperience);
        }

        [Test]
        public void DummyLoosesHealthAfterAttacked()
        {
            dummy.TakeAttack(3);

            Assert.That(dummy.Health, Is.EqualTo(7));
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            dummy.TakeAttack(10);

            Assert.That(() => dummy.TakeAttack(10), 
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            dummy.TakeAttack(10);

            int experience = dummy.GiveExperience();

            experience.Should().Be(10);
        }

        [Test]
        public void AliveDummyCantGiveExperience()
        {
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
