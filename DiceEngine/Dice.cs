namespace DiceEngine; 
public class Dice {
    private static Random _rnd = new Random();
    public static Dice D(int sideCount) {
        return new Dice(sideCount);
    }

    public static List<Dice> operator *(int n, Dice d) {
        List<Dice> result = new List<Dice>();
        for (int i = 0;  i < n; i++) result.Add(new Dice(d));
        return result;
    }

    public readonly int[] Sides;
    public int SideCount => Sides.Length;
    public int Value { get; private set; }

    public Dice(int sideCount) {
        Sides = new int[sideCount];
        for (int i = 0; i <  sideCount; i++)
            Sides[i] = i + 1;
        Value = Sides[0];
    }

    public Dice(int[] sides) {
        Sides = sides;
        Value = Sides[0];
    }

    public Dice(Dice other) : this(other.Sides) { }

    public int Roll() {
        var index = _rnd.Next(SideCount);
        Value = Sides[index];
        return Value;
    }
}


