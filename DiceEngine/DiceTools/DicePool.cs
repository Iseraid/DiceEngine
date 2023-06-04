using System.Collections;

namespace DiceEngine.DiceTools;
public class DicePool : IEnumerable<Dice> {
    public List<Dice> Pool { get; set; } = new List<Dice>();
    public Dice this[int i] {
        get => Pool[i]; 
    }
    public int DiceCount => Pool.Count;
    

    public DicePool() { }

    public DicePool(List<Dice> dicePool) {
        Pool = dicePool;
    }

    public DicePool(Dice dice, int count) {
        for (int i = 0; i < count; i++) {
            Pool.Add(dice);
        }
    }

    public Dice AddDice(Dice dice) {
        Pool.Add(dice);
        return dice;
    }

    public void RemoveDice(Dice dice) {
        Pool.Remove(dice);
    }

    public void RemoveDice() {
        if (DiceCount > 0)
            Pool.RemoveAt(0);
    }

    public int[] Roll() {
        int[] result = new int[DiceCount];
        for (int i = 0; i < DiceCount; i++) {
            
        }
        return result;
    }

    public IEnumerator<Dice> GetEnumerator() {
        return Pool.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return Pool.GetEnumerator();
    }

    public override string ToString() {
        string dicePool = "";
        for (var i = 0; i < DiceCount; i++) {
            dicePool+= (i + 1 == DiceCount) ? $"{Pool[i]}" : $"{Pool[i]}, ";
        }
        return $"{{{dicePool}}}";
    }
}
