using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{

    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }
    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShouldBeSetCorrectly()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }
    [Test]

    public void When_AxeAttacksShouldLooseDurabilityPoints()
    {
        axe.Attack(dummy);
        Assert.AreEqual(axe.DurabilityPoints, durability - 1);

    }

    [Test]
    public void When_AxeAttatkDurabilityPointsAreZero_ShouldThrowExeption()
    {
        dummy = new Dummy(5000, 5000);
        Exception ex = Assert.Throws<InvalidOperationException>(() =>
          {
              for (int i = 0; i < durability + 1; i++)
              {
                  axe.Attack(dummy);
              }
          });
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
    [Test]
    public void When_AxeAttackIsCalledWithNullDummy_ShouldThrowNullRef()
    {
        Assert.Throws<NullReferenceException>(() =>
        {
            for (int i = 0; i < durability + 1; i++)
            {
                axe.Attack(null);
            }
        });
    }


}