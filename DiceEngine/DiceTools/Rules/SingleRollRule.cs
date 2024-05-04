using DiceEngine.DiceTools.Actions;

namespace DiceEngine.DiceTools.Rules; 

public class SingleRollRule {
    private ISingleInputAction FirstAction { get; set; }
    private ISingleOutputAction LastAction { get; set; }

    public SingleRollRule(ISingleInputAction firstAction, ISingleOutputAction lastAction) {
        FirstAction = firstAction;
        LastAction = lastAction;
    }
    public RollResult Apply(Dice dice) => Apply(dice.Roll());
    public RollResult Apply(RollResult input) {
        FirstAction.Input = input;
        return LastAction.Perform();
    }
}