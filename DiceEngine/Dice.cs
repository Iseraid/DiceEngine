namespace DiceEngine; 
public class Dice {
    private static Random _rnd = new Random();
    /// <summary>
    /// Creates a dice with specified amount of sides and puts standart values on them. 
    /// (For example, a d6 created this way would have values: {1, 2, 3, 4, 5, 6}
    /// </summary>
    /// <param name="sideCount">Amount of sides.</param>
    public static Dice D(int sideCount) {
        return new Dice(sideCount);
    }

    /// <summary>
    /// Makes a list of <paramref name="n"/> copies of <paramref name="dice"/>.
    /// </summary>
    /// <param name="n">Number of dice.</param>
    /// <param name="dice">Dice to replicate.</param>
    /// <returns></returns>
    public static List<Dice> operator *(int n, Dice dice) {
        List<Dice> result = new List<Dice>();
        for (int i = 0;  i < n; i++) result.Add(new Dice(dice));
        return result;
    }

    public readonly int[] Sides;
    public int SideCount => Sides.Length;
    /// <summary>
    /// Current dice value.
    /// </summary>
    public int Value { get; private set; }

    /// <summary>
    /// Creates a dice with specified amount of sides and puts standart values on them. 
    /// (For example, a d6 created this way would have values: {1, 2, 3, 4, 5, 6}
    /// </summary>
    /// <param name="sideCount">Amount of sides.</param>
    public Dice(int sideCount) {
        Sides = new int[sideCount];
        for (int i = 0; i <  sideCount; i++)
            Sides[i] = i + 1;
        Value = Sides[0];
    }

    /// <summary>
    /// Creates a dice with specified values on its sides.
    /// </summary>
    /// <param name="sides">Values to put on the sides of the dice.</param>
    public Dice(int[] sides) {
        Sides = sides;
        Value = Sides[0];
    }

    /// <summary>
    /// Creates copy of a dice.
    /// </summary>
    /// <param name="other">Dice to copy.</param>
    public Dice(Dice other) : this(other.Sides) { }

    /// <summary>
    /// Rolls the dice, changing its current value.
    /// </summary>
    /// <returns>New dice value.</returns>
    public int Roll() {
        var index = _rnd.Next(SideCount);
        Value = Sides[index];
        return Value;
    }
}


