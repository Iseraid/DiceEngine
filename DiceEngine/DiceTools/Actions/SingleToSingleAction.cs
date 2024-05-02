namespace DiceEngine.DiceTools.Actions; 

public class SingleToSingleAction : RuleAction, ISingleInputAction {
    private Func<RollResult, RollResult> ActionFunction { get; set; }
    private ISingleInputAction? FollowingAction { get; set; }
    
    public SingleToSingleAction(Func<RollResult, RollResult> actionFunction) {
        ActionFunction = actionFunction;
    }

    public void Perform(RollResult input, out RollResult finalResult) {
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