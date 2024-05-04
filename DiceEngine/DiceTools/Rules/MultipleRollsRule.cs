using DiceEngine.DiceTools.Actions;

namespace DiceEngine.DiceTools.Rules; 

public class MultipleRollsRule {
    private IMultipleInputAction ActionChainStart { get; set; }
    private ISingleOutputAction ActionChainEnd { get; set; }

    public MultipleRollsRule(IMultipleInputAction actionChainStart, ISingleOutputAction actionChainEnd) {
        ActionChainStart = actionChainStart;
        ActionChainEnd = actionChainEnd;
    }
    public RollResult Apply(List<Dice> dice) => Apply(dice.Roll());
    public RollResult Apply(List<RollResult> input) {
        ActionChainStart.Input = input;
        return ActionChainEnd.Perform();
    }
}