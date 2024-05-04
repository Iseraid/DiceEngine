namespace DiceEngine.DiceTools.Actions; 

public class MultipleToSingleAction : RuleAction, IMultipleInputAction, ISingleOutputAction {
    private Func<List<RollResult>, RollResult> ActionFunction { get; set; }
    private IMultipleOutputAction? PreviousAction { get; set; }
    public List<RollResult>? Input { get; set; }
    
    public MultipleToSingleAction(
        Func<List<RollResult>, RollResult> actionFunction, 
        IMultipleOutputAction? previousAction = null) 
    {
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