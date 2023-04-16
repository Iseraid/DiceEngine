namespace DiceEngine;
public class DicePool {
    private List<Dice> _dicePool = new List<Dice>();
    public int DiceCount => _dicePool.Count;

    public DicePool() { }

    public DicePool(List<Dice> dicePool) {
        _dicePool = dicePool;
    }

    public DicePool(Dice dice, int count) {
        for (int i = 0; i < count; i++) {
            _dicePool.Add(dice);
        }
    }

    public Dice AddDice(Dice dice) {
        _dicePool.Add(dice);
        return dice;
    }

    public void RemoveDice(Dice dice) {
        _dicePool.Remove(dice);
    }

    public void RemoveDice() {
        if (DiceCount > 0)
            _dicePool.RemoveAt(0);
    }

    public DicePool Roll() {
        foreach (Dice dice in _dicePool) {
            dice.Roll();
        }
        return this;
    }
}
