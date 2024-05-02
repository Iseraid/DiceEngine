namespace DiceEngine.DiceTools.Actions; 

public class MultipleToMultipleAction : RuleAction, IMultipleInputAction {
    private Func<List<RollResult>, List<RollResult>> ActionFunction { get; set; }
    public IMultipleInputAction? FollowingAction { get; set; }

    public MultipleToMultipleAction(Func<List<RollResult>, List<RollResult>> actionFunction) {
        ActionFunction = actionFunction;
    }

    public void Perform(List<RollResult> input, out RollResult finalResult) {
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