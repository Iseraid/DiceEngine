namespace DiceEngine.DiceTools.Rules;

public interface IRuleDescriptor<T>
{
    public Rule<T> Finish();
}