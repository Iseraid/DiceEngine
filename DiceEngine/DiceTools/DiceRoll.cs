namespace DiceEngine.DiceTools;
public class DiceRoll {
    private DicePool _pool;
    private int[] _diceValues;
    private ResultFormula _formula;
    public DiceRoll(DicePool pool, ResultFormula resultFormula) {
        _pool = pool;
        _diceValues = pool.Roll();
        _formula = resultFormula;
    }

    /*public int Make() {
        _diceValues = _pool.Roll();
        _formula.Invoke(_diceValues, )
    }*/

}

