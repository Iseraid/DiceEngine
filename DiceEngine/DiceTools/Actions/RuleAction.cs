namespace DiceEngine.DiceTools.Actions; 

public static class RuleAction {
    public static SingleToSingleAction For(Func<RollResult, RollResult> function) => new(function);
    public static SingleToMultipleAction For(Func<RollResult, List<RollResult>> function) => new(function);
    public static MultipleToSingleAction For(Func<List<RollResult>, RollResult> function) => new(function);
    public static MultipleToMultipleAction For(Func<List<RollResult>, List<RollResult>> function) => new(function);

}