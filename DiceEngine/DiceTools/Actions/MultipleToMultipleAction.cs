namespace DiceEngine.DiceTools.Actions; 

public class MultipleToMultipleAction : RuleAction, IMultipleInputAction, IMultipleOutputAction {
    private Func<List<RollResult>, List<RollResult>> ActionFunction { get; set; }
    public IMultipleOutputAction? PreviousAction { get; private set; }
    public List<RollResult>? Input { get; set; }
    
    public MultipleToMultipleAction(
        Func<List<RollResult>, List<RollResult>> actionFunction, 
        IMultipleOutputAction? previousAction = null) 
    {
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