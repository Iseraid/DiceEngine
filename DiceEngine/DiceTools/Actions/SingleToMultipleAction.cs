namespace DiceEngine.DiceTools.Actions; 

public class SingleToMultipleAction : RuleAction, ISingleInputAction {
    private Func<RollResult, List<RollResult>> ActionFunction { get; set; }
    private IMultipleInputAction? FollowingAction { get; set; }

    public SingleToMultipleAction(Func<RollResult, List<RollResult>> actionFunction) {
        ActionFunction = actionFunction;
    }
    public void Perform(RollResult input, out RollResult finalResult) {
        var output = ActionFunction(input);
        if (FollowingAction == null)
            throw new NullReferenceException(
                "Actions that return multiple roll results must have a continuation with a single roll result output!");
        FollowingAction.Perform(output, out finalResult);
    }
    
    public MultipleToSingleAction FollowWith(MultipleToSingleAction action) {
        FollowingAction = action;
        return action;
    }

    public MultipleToMultipleAction FollowWith(MultipleToMultipleAction action) {
        FollowingAction = action;
        return action;
    }
}