using System;
using System.Data.Common;

namespace DiceEngine.Utilities;
public class Fraction {

    public static implicit operator float(Fraction frac) => (float) frac.N / frac.D;
    public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.N * b.N, a.D * b.D);
    public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.N * b.D, a.D * b.N);
    public static Fraction operator +(Fraction a, Fraction b) {
        if (a.D == b.D)
            return new Fraction(a.N + b.N, a.D);
        int newDenum = a.D * b.D;
        int newNum = a.N * b.D + b.N * a.D;
        return new Fraction(newNum, newDenum);
    }
    public static Fraction operator -(Fraction a, Fraction b) {
        b.N = -b.N;
        return a + b;
    }
    /// <summary>
    /// Numerator.
    /// </summary>
    public int N { get; set; }
    /// <summary>
    /// Denumerator.
    /// </summary>
    public int D { get; set; } = 1;
    public Fraction(int num, int denum) {
        if (denum == 0)
            throw new DivideByZeroException();
        int divider = Utils.GCD(denum, num);
        if (divider != 1) {
            num /= divider;
            denum /= divider;
        }
        N = num;
        D = denum;
    }

    public override string ToString() {
        return $"{N}/{D}";
    }
}
