namespace DiceEngine.DiceTools.Rules;

public abstract class Rule
{
    protected Rule()
    {
    }

    public static IRuleDescriptor<T> ForCharSheet<T>() => new RuleDescriptor<T>();
}

public class Rule<T>
{
    protected IRuleDescriptor<T> Descriptor { get; set; }
    public Rule(IRuleDescriptor<T> descriptor)
    {
        Descriptor = descriptor;
    }
}