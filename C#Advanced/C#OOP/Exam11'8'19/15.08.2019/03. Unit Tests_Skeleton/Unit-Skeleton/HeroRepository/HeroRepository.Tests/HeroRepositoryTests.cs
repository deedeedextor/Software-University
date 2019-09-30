using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private Hero hero1;
    private Hero hero2;
    private Hero hero3;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        this.hero = new Hero("Ivan", 3);
        this.hero1 = new Hero("Pesho", 5);
        this.hero2 = new Hero("Drago", 10);
        this.hero3 = new Hero("Kris", 9);
        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void TestIfConstructorsWorksCorrectly()
    {
        Assert.AreEqual("Ivan", this.hero.Name);
        Assert.AreEqual(3, this.hero.Level);

        Assert.IsNotNull(this.heroRepository);
    }

    [Test]
    public void TestIfCreateReturnsTheRightMessage()
    {
        string expectedMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";
        string actualMessage = this.heroRepository.Create(hero);

        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void TestIfCreateWorksCorrectly()
    {
        this.heroRepository.Create(hero);

        Assert.AreEqual(1, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void TestIfCreateThrowsExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Create(null);
        });
    }

    [Test]
    public void TestIfCreateThrowsExceptionWhenAdditingTheSameHero()
    {
        this.heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            this.heroRepository.Create(hero);
        });
    }

    [Test]
    public void TestIfRemoveWorksCorrectly()
    {
        this.heroRepository.Create(hero);

        Assert.AreEqual(true, this.heroRepository.Remove("Ivan"));
    }

    [Test]
    public void TestIfRemoveReturnsExceptionWhenHeroNamesIsNull()
    {
        this.heroRepository.Create(hero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Remove(null);
        });
    }

    [Test]
    public void TestIfGetHeroWithHighestLevelWorksCorrectly()
    {
        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        Assert.AreEqual(hero2, this.heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void TestIfGetHeroWorksCorrectly()
    {
        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        Assert.AreEqual(hero3, this.heroRepository.GetHero("Kris"));
    }
}