using DiceEngine.DiceTools.Actions;

namespace DiceEngine.DiceTools.Rules; 

public class SingleRollRule {
    private ISingleInputAction ActionChainStart { get; set; }
    private ISingleOutputAction ActionChainEnd { get; set; }

    public SingleRollRule(ISingleInputAction actionChainStart, ISingleOutputAction actionChainEnd) {
        ActionChainStart = actionChainStart;
        ActionChainEnd = actionChainEnd;
    }
    public RollResult Apply(Dice dice) => Apply(dice.Roll());
    public RollResult Apply(RollResult input) {
        ActionChainStart.Input = input;
        return ActionChainEnd.Perform();
    }
}