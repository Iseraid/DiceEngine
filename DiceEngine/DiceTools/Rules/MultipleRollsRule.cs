namespace DiceEngine.DiceTools.Rules; 

public class MultipleRollsRule {
    internal MultipleRollsRule() {
    }

    public RollResult Apply(List<Dice> dice) => Apply(dice.Roll());
    
    public RollResult Apply(List<RollResult> input) {
        throw new NotImplementedException();
    }
}