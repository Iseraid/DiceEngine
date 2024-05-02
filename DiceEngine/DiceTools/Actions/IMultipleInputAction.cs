namespace DiceEngine.DiceTools.Actions; 

public interface IMultipleInputAction {
    public void Perform(List<RollResult> input, out RollResult finalResult);
}