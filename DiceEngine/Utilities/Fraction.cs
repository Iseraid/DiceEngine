namespace DiceEngine.Utilities;
public class Fraction {
    public int Numerator { get; set; }
    public int Denumenator { get; set; } = 1;
    public Fraction(int num, int denum) {
        if (denum == 0)
            throw new DivideByZeroException();
        Numerator = num;
        Denumenator = denum;
    }

    public static implicit operator float(Fraction frac) => (float) frac.Numerator / frac.Denumenator;
}
