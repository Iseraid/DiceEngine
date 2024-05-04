using DiceEngine.DiceTools;
using DiceEngine.DiceTools.Actions;
using DiceEngine.DiceTools.Extensions;
using DiceEngine.DiceTools.Rules;
using NUnit.Framework;

namespace DiceEngine.Tests;

public class RulesAndActionsTests
{
    [Test]
    public void RuleActions_Test()
    {
        // Here we want to roll 3d6, sum them and call it a success if result is lower than 12
        
        var action1 = new MultipleToSingleAction(input => input.Sum());
        var action2 = new SingleToSingleAction(input =>
            input.IntervalTransform((3, 12, 1), (13, 18, -1)), action1);
        action1.Input = (3 * Dice.D(6)).Roll();
        var result = action2.Perform();
        TestContext.WriteLine(string.Join(", ", result.Probabilities
            .Select((prob) => $"{prob.Key}:{prob.Value}")));
    }

    [Test]
    public void ChainingActions_Test() {
        var startAction = RuleAction.For(input => input.Sum());
        startAction.Input = (3 * Dice.D(6)).Roll();
        var endAction = startAction.FollowWith(input => input.IntervalTransform((3, 12, 1), (13, 18, -1)));
        var result = endAction.Perform();
        TestContext.WriteLine(string.Join(", ", result.Probabilities
            .Select((prob) => $"{prob.Key}:{prob.Value}")));
    }
}

