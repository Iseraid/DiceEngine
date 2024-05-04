namespace DiceEngine.DiceTools.Actions; 

public class SingleToSingleAction : ISingleInputAction, ISingleOutputAction {
    private Func<RollResult, RollResult> ActionFunction { get; set; }
    private ISingleOutputAction? PreviousAction { get; set; }
    public RollResult? Input { get; set; }
    
    public SingleToSingleAction(
        Func<RollResult, RollResult> actionFunction,
        ISingleOutputAction? previousAction = null) {
        ActionFunction = actionFunction;
        PreviousAction = previousAction;
    }
    
    public RollResult Perform() {
        if (PreviousAction != null) return ActionFunction(PreviousAction.Perform());
        if (Input == null)
            throw new NullReferenceException("Action required input, but it wasn't provided.");
        return ActionFunction(Input);
    }
}