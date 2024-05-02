namespace DiceEngine.DiceTools.Actions; 

public interface ISingleInputAction {
    public void Perform(RollResult input, out RollResult finalResult);
}