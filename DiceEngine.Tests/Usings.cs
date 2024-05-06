using DiceEngine.DiceTools;
using DiceEngine.DiceTools.Actions;
using DiceEngine.DiceTools.Extensions;
using NUnit.Framework;

namespace DiceEngine.Tests; 

public class SystemTest {
    private Dice Dice { get; set; }
    [SetUp]
    public void SetUp() {
        Dice = new Dice(new[] { -3, -2, -1, -1, 0, 1, 1, 2, 2, 3 });
    }

    [Test]
    public void RollOutcome_Test() {
        var roll = Dice.Roll();
        TestContext.WriteLine(string.Join(", ", roll.Probabilities
            .Select((prob) => $"{prob.Key}:{prob.Value}")));
    }

    [Test]
    public void RollMultipleOutcome_Test() {
        var dice = 10 * Dice;
        var roll = dice.Roll().Sum();
        roll = roll.IntervalReMap(
            (-30, -1, -1), 
            (0, 0, 0), 
            (1, 30, 1)
            );
        TestContext.WriteLine(string.Join(", ", roll.Probabilities
            .Select((prob) => $"{prob.Key}:{prob.Value}")));
    }

    [TestCase(4, -2)]
    [TestCase(4, -1)]
    [TestCase(4, 0)]
    [TestCase(4, 1)]
    [TestCase(4, 2)]
    public void Test(int diceCount, int offset) {
        var rolls = (diceCount * Dice.D(10)).Roll();
        rolls = rolls.Select(d =>
            d.ReMap(new Dictionary<int, int> {
                {1, -3},
                {2, -2},
                {3, -1},
                {4, -1},
                {5, 0},
                {6, 1},
                {7, 1},
                {8, 2},
                {9, 2},
                {10, 3}
            })
        ).ToList();
        var res = rolls.Sum().IntervalReMap((int.MinValue, -1, -1), (0, 0, 0), (1, int.MaxValue, 1));
        res.SaveToFile($"Result_{diceCount}d10_with_offset_{offset}.txt", "P");
    }
}