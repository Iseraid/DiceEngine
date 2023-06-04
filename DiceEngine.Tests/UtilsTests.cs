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
        frac.Denumenator = 9;
        Assert.True(frac == 1f/3);
    }
}
