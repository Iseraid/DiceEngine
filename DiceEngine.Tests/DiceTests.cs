using DiceEngine.DiceTools;
using System.Collections.ObjectModel;

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
            Assert.That(actualDice.ToString(), Is.EqualTo(expectedDice.ToString()));
        }
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = "d6 (1, 2, 3, 4, 5, 6)")]
    [TestCase(new int[] { 3, 5, 7, 9 }, ExpectedResult = "d4 (3, 5, 7, 9)")]
    public string DiceToStringWithDetails(int[] sides) {
        Dice d = new Dice(sides);
        return d.ToString();
    }

    [Test]
    public void DiceRoll_Static_Method_Single_D10() { 
        Dice d = Dice.D(10);
        var result = d.Roll();
        Dictionary<int, float> actual = new Dictionary<int, float>();
        for (int i = 0; i < d.SideCount; i++)
            actual[d.Sides[i]] = 1f / 10;
        Assert.That(actual, Is.EqualTo(result.Probabilities));
    }

    [Test]
    public void DiceRoll_Static_Method_3_D10() {
        List<Dice> dice = 3 * Dice.D(10);
        var result = dice.Roll();
        Dictionary<int, float> actual = new Dictionary<int, float>();
        for (int i = 0; i < dice[0].SideCount; i++)
            actual[dice[0].Sides[i]] = 1f / 10;
        foreach (var r in result)
            Assert.That(actual, Is.EqualTo(r.Probabilities));
    }
}