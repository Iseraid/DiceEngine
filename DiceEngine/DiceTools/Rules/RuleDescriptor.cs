namespace DiceEngine.DiceTools.Rules;

public class RuleDescriptor<T> : IRuleDescriptor<T>
{
    public ICheckDescriptor<T> Check(string checkName)
    {
        throw new NotImplementedException();
    }

    public Rule<T> Finish() => new(this);
}