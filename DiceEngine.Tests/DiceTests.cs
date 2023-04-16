using DiceEngine.DiceTools;

namespace DiceEngine.Tests;

public class DiceTests {
    [SetUp]
    public void Setup() {

    }

    [Test]
    public void Multiply_3_D6() {

        var actual = 3 * Dice.D(6);
        var expected = new List<Dice> { Dice.D(6), Dice.D(6), Dice.D(6) };
        Assert.That(actual.Count, Is.EqualTo(expected.Count));
        for (int i = 0; i < expected.Count; i++) {
            var actualDice = actual[i];
            var expectedDice = expected[i];
            for (int j = 0; j < actualDice.SideCount; j++) {
                Assert.That(actualDice.Sides[j] == expectedDice.Sides[j]);
            }

        }
    }

    [Test]
    public void DicePoolEnumeration_4_D10() {
        DicePool pool = new DicePool(4*Dice.D(10));
        int count = 0;
        foreach (var d in pool) {
            Assert.IsTrue(d.SideCount == 10);
            count++;
        }
        Assert.That(count, Is.EqualTo(4));
    }
}