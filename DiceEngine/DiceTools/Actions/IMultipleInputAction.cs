namespace DiceEngine.DiceTools.Actions; 

public interface IMultipleInputAction {
    public List<RollResult> Input { get; set; }
}