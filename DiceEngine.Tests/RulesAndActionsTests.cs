using DiceEngine.DiceTools;
using DiceEngine.DiceTools.Actions;
using DiceEngine.DiceTools.Rules;
using NUnit.Framework;

namespace DiceEngine.Tests;

public class RulesAndActionsTests
{
    [Test]
    public void ChainingActions_Test()
    {
        // Here we want to roll 3d6, summ them and call it a success if result is lower than 12
        var roll = (3 * Dice.D(6)).Roll();
        var action = new MultipleToSingleAction(input => input.Sum());
        action.FollowWith(new SingleToSingleAction(input => {
                return input.IntervalTransform((3, 12, 1), (13, 18, -1));
            }));
        action.Perform(roll, out var result);
        TestContext.WriteLine(string.Join(", ", result.Probabilities
            .Select((prob) => $"{prob.Key}:{prob.Value}")));
        TestContext.WriteLine($"Sum is {result.Probabilities.Values.Sum()}");
        //var rule = Rule.Roll(Dice...).Sum().DefineSuccessAs(...)
        //rule.Apply(14*Dice.D(6))
    }
}

