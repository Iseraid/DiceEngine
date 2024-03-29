﻿namespace DiceEngine.DiceTools;
public class Dice {
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
        for (int i = 0; i < n; i++)
            result.Add(new Dice(dice));
        return result;
    }

    public readonly int[] Sides;
    public int SideCount => Sides.Length;

    /// <summary>
    /// Creates a dice with specified amount of sides and puts standart values on them. 
    /// (For example, a d6 created this way would have values: {1, 2, 3, 4, 5, 6})
    /// </summary>
    /// <param name="sideCount">Amount of sides.</param>
    public Dice(int sideCount) {
        Sides = new int[sideCount];
        for (int i = 0; i < sideCount; i++)
            Sides[i] = i + 1;
    }

    /// <summary>
    /// Creates a dice with specified values on its sides.
    /// </summary>
    /// <param name="sides">Values to put on the sides of the dice.</param>
    public Dice(int[] sides) {
        Sides = sides.ToArray(); //It actually copies values and not the reference
    }

    /// <summary>
    /// Creates copy of a dice.
    /// </summary>
    /// <param name="other">Dice to copy.</param>
    public Dice(Dice other) : this(other.Sides) { }

    public string ToString(bool incudeDetails = true) {
        string dice = $"d{SideCount}";
        if (!incudeDetails) return dice;
        string details = "";
        for (var i = 0; i < SideCount; i++) {
            details += (i + 1 == SideCount) ? $"{Sides[i]}" : $"{Sides[i]}, ";
        }
        return $"{dice} ({details})";
    }

    public override string ToString() {
        return ToString();
    }
}


