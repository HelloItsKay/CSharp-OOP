
using FakeAxeAndDummy;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{

    [Test]
    public void HeroGainsExperienceWhenKill()
    {

        string name = "Pesho";
      IWeapon fakeWeapon=new FakeAxe();
      ITarget fakeTarget=new FakeDummy();
      Hero hero=new Hero(name, fakeWeapon);
      hero.Attack(fakeTarget);
      Assert.That(hero.Experience, Is.EqualTo(20));
    }
}