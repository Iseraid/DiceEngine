using DiceEngine.DiceTools.Actions;

namespace DiceEngine.DiceTools.Rules; 

public class MultipleRollsRule {
    private IMultipleInputAction FirstAction { get; set; }
    private ISingleOutputAction LastAction { get; set; }

    public MultipleRollsRule(IMultipleInputAction firstAction, ISingleOutputAction lastAction) {
        FirstAction = firstAction;
        LastAction = lastAction;
    }
    public RollResult Apply(List<Dice> dice) => Apply(dice.Roll());
    public RollResult Apply(List<RollResult> input) {
        FirstAction.Input = input;
        return LastAction.Perform();
    }
}