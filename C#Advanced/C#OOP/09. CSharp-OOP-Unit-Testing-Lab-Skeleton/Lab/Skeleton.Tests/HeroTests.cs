namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;
    using Skeleton.Tests.FakeObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestFixture]
    public class HeroTests
    {
        private const string HeroName = "Hero";
        [Test]
        public void HeroGainsExperienceAfterAttackWhenTargetDies()
        {
            IWeapon fakeWeapon = new FakeWeapon();
            ITarget fakeTarget = new FakeTarget();

            Hero hero = new Hero(HeroName, fakeWeapon);

            hero.Attack(fakeTarget);
            var expectedExperience = fakeTarget.GiveExperience();

            Assert.AreEqual(expectedExperience, hero.Experience);
        }

        public void HeroGainsExperienceAfterAttackWhenTargetDiesMoqVersion()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(ft => ft.Health).Returns(0);
            fakeTarget.Setup(ft => ft.GiveExperience()).Returns(20);
            fakeTarget.Setup(ft => ft.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero hero = new Hero(HeroName, fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(10, hero.Experience);
        }
    }
}
