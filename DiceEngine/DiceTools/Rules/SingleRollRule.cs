namespace DiceEngine.DiceTools.Rules; 

public class SingleRollRule {
    protected List<Func<RollResult, RollResult>> Actions { get; } = new();
    
    internal SingleRollRule() {
    }
    
    
    
    public RollResult Apply(Dice dice) => Apply(dice.Roll());
    
    public RollResult Apply(RollResult input) {
        throw new NotImplementedException();
    }
}