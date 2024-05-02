namespace DiceEngine.DiceTools.Rules; 

public class Rule {

    public static SingleRollRule OnSingleRollResult() => new();
    public static MultipleRollsRule OnMultipleRollResults() => new();
}
