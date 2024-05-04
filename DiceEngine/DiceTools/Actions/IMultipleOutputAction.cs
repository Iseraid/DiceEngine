namespace DiceEngine.DiceTools.Actions; 

public interface IMultipleOutputAction {
    public List<RollResult> Perform();
}