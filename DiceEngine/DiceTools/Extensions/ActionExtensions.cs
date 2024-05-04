using DiceEngine.DiceTools.Actions;

namespace DiceEngine.DiceTools.Extensions; 

public static class ActionExtensions {
    
    public static SingleToSingleAction FollowWith(
        this ISingleOutputAction action, 
        Func<RollResult, RollResult> function) 
        => new(function, action);

    public static SingleToMultipleAction FollowWith(
        this ISingleOutputAction action,
        Func<RollResult, List<RollResult>> function)
        => new(function, action);

    public static MultipleToSingleAction FollowWith(
        this IMultipleOutputAction action,
        Func<List<RollResult>, RollResult> function)
        => new(function, action);
    
    public static MultipleToMultipleAction FollowWith(
        this IMultipleOutputAction action,
        Func<List<RollResult>, List<RollResult>> function)
        => new(function, action);

    public static SingleToSingleAction WithInput(this SingleToSingleAction action, RollResult input) {
        action.Input = input;
        return action;
    }
    
    public static SingleToMultipleAction WithInput(this SingleToMultipleAction action, RollResult input) {
        action.Input = input;
        return action;
    }
    
    public static MultipleToSingleAction WithInput(this MultipleToSingleAction action, List<RollResult> input) {
        action.Input = input;
        return action;
    }
    
    public static MultipleToMultipleAction WithInput(this MultipleToMultipleAction action, List<RollResult> input) {
        action.Input = input;
        return action;
    }
}