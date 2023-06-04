using System.Linq.Expressions;

namespace DiceEngine.DiceTools;
public class ResultFormula {
    private Dictionary<string, float> _parameters = new Dictionary<string, float>();
    private Func<int[], Dictionary<string, float>, int> _formula;
    private ResultFormula(Dictionary<string, float> parameters, Func<int[], Dictionary<string, float>, int> formula) { 
        _parameters = parameters;
        _formula = formula;
    }
}
