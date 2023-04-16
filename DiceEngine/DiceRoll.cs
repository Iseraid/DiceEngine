namespace DiceEngine;
public class DiceRoll {
    private List<Dice> _dicePool = new List<Dice>();
    public int DiceCount => _dicePool.Count;

    public DiceRoll() { }

    public DiceRoll(List<Dice> dicePool) {
        _dicePool = dicePool;
    }

    public DiceRoll(Dice dice, int count) {
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

    public DiceRoll Roll() {
        foreach (Dice dice in _dicePool) {
            dice.Roll();
        }
        return this;
    }
}
