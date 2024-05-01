using DiceEngine.DiceTools;
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
        roll = roll.IntervalTransform(
            (-30, -1, -1), 
            (0, 0, 0), 
            (1, 30, 1)
            );
        TestContext.WriteLine(string.Join(", ", roll.Probabilities
            .Select((prob) => $"{prob.Key}:{prob.Value}")));
    }
}