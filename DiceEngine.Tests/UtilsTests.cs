using DiceEngine.Utilities;

namespace DiceEngine.Tests;

public class UtilsTests {
    [SetUp]
    public void Setup() {

    }

    [Test]
    public void FractionTest_Cast_To_Float() {
        Fraction frac = new Fraction(3, 10);
        float res = frac;
        Assert.That(res, Is.EqualTo(0.3f));
        frac.D = 9;
        Assert.True(frac == 1f/3);
    }

    [Test]
    public void FractionTest_Arithmetics() {
        Fraction x = new Fraction(-5, 7);
        Fraction y = new Fraction(3, 5);
        Fraction mult = x * y;
        Assert.That(mult.ToString(), Is.EqualTo("-3/7"));
        Fraction div = x / y;
        Assert.That(div.ToString(), Is.EqualTo("-25/21"));
        Fraction sum = x + y;
        Assert.That(sum.ToString(), Is.EqualTo("-4/35"));
        Fraction sub = x - y;
        Assert.That(sub.ToString(), Is.EqualTo("-46/35"));
        TestContext.WriteLine($"mult {mult}, div {div}, sum {sum}, sub {sub}");
    }

    [Test]
    public void FractionTest() { }
}
