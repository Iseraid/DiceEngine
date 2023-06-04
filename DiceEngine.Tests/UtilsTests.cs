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
        Fraction x = new Fraction(5, 7);
        Fraction y = new Fraction(3, 5);
        Fraction mult = x * y;
        Fraction div = x / y;
        Fraction sum = x + y;
        Fraction sub = x - y;
        TestContext.WriteLine($"mult {mult}, div {div}, sum {sum}, sub {sub}");
    }

    [Test]
    public void FractionTest() { }
}
