namespace DiceEngine.DiceTools.Actions; 

public class MultipleToSingleAction : RuleAction, IMultipleInputAction {
    private Func<List<RollResult>, RollResult> ActionFunction { get; set; }
    private ISingleInputAction? FollowingAction { get; set; }

    public MultipleToSingleAction(Func<List<RollResult>, RollResult> actionFunction) {
        ActionFunction = actionFunction;
    }
    public void Perform(List<RollResult> input, out RollResult finalResult) {
        var output = ActionFunction(input);
        if (FollowingAction != null)
            FollowingAction.Perform(output, out finalResult);
        else 
            finalResult = output;
    }
    
    public SingleToSingleAction FollowWith(SingleToSingleAction action) {
        FollowingAction = action;
        return action;
    }

    public SingleToMultipleAction FollowWith(SingleToMultipleAction action) {
        FollowingAction = action;
        return action;
    }
}