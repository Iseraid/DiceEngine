namespace DiceEngine.DiceTools.Actions; 

public class SingleToMultipleAction : RuleAction, ISingleInputAction, IMultipleOutputAction {
    private Func<RollResult, List<RollResult>> ActionFunction { get; set; }
    private ISingleOutputAction? PreviousAction { get; set; }
    public RollResult? Input { get; set; }
    
    public SingleToMultipleAction(
        Func<RollResult, List<RollResult>> actionFunction,
        ISingleOutputAction? previousAction = null) {
        ActionFunction = actionFunction;
        PreviousAction = previousAction;
    }
    
    public List<RollResult> Perform() {
        if (PreviousAction != null) return ActionFunction(PreviousAction.Perform());
        if (Input == null)
            throw new NullReferenceException("Action required input, but it wasn't provided.");
        return ActionFunction(Input);
    }
}