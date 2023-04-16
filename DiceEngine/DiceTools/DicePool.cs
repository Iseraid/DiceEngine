using System.Collections;

namespace DiceEngine.DiceTools;
public class DicePool : IEnumerable<Dice> {
    public List<Dice> Dice { get; set; } = new List<Dice>();
    public int DiceCount => Dice.Count;

    public DicePool() { }

    public DicePool(List<Dice> dicePool) {
        Dice = dicePool;
    }

    public DicePool(Dice dice, int count) {
        for (int i = 0; i < count; i++) {
            Dice.Add(dice);
        }
    }

    public Dice AddDice(Dice dice) {
        Dice.Add(dice);
        return dice;
    }

    public void RemoveDice(Dice dice) {
        Dice.Remove(dice);
    }

    public void RemoveDice() {
        if (DiceCount > 0)
            Dice.RemoveAt(0);
    }

    public IEnumerator<Dice> GetEnumerator() {
        return Dice.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return Dice.GetEnumerator();
    }
}
