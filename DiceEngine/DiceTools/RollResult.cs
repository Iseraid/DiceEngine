﻿using DiceEngine.Utilities;
using System.Collections.ObjectModel;

namespace DiceEngine.DiceTools;
public class RollResult {
    public static RollResult operator +(RollResult res1, RollResult res2) {
        RollResult result = new RollResult();
        foreach (var p in res1._probabilities) {
            foreach (var q in res2._probabilities) {
                int val = p.Key + q.Key;
                var prob = p.Value * q.Value;
                result.AddProbability(val, prob);
            }
        }
        return result;
    }

    private Dictionary<int, decimal> _probabilities = new Dictionary<int, decimal>();
    public ReadOnlyDictionary<int, float> Probabilities => 
        new ReadOnlyDictionary<int, float>(_probabilities.ToDictionary(pair =>  pair.Key, pair => (float) pair.Value));

    private RollResult() { }

    private void AddProbability(int value, decimal probability) {
        if (_probabilities.ContainsKey(value)) {
            _probabilities[value] += probability;
        } else {
            _probabilities[value] = probability;
        }
    }

    /// <summary>
    /// Creates a result for rolling a dice.
    /// </summary>
    /// <param name="dice">The dice whose roll result is being created.</param>
    public RollResult(Dice dice) {
        decimal sideProb = 1M / dice.SideCount;//new Fraction(1, dice.SideCount);
        foreach (var side in dice.Sides) {
            AddProbability(side, sideProb);
        }
    }

    /// <summary>
    /// Applies transformation to roll result that maps previous roll values and probabilities 
    /// to new ones by the supplied accordance law.
    /// </summary>
    /// <param name="accordance">Accordance used to map previous roll values and probabilities.</param>
    /// <returns>Roll result transformed by the specified accordance law.</returns>
    public RollResult Transform(Dictionary<int, int> accordance) {
        RollResult result = new RollResult();
        result._probabilities = new Dictionary<int, decimal>();
        foreach (var valProbPair in _probabilities) {
            //Find if we have an according new value for an old one. If we do, then
            //save it to a newVal and also save old value probability to valProb
            if (!accordance.ContainsKey(valProbPair.Key))
                continue;
            int newVal = accordance[valProbPair.Key];
            decimal valProb = valProbPair.Value;

            //Add probability (in additive manner) to the new roll result dictionary
            result.AddProbability(newVal, valProb);
        }
        return result;
    }

    /// <summary>
    /// Applies transformation to roll result that maps previous roll values and probabilities 
    /// to new ones by the supplied accordance law.
    /// </summary>
    /// <param name="accordanceFunc">Accordance used to map previous roll values and probabilities.</param>
    /// <returns>Roll result transformed by the specified accordance law.</returns>
    public RollResult Transform(Func<int[], int[]> accordanceFunc) {
        int[] prevValues = _probabilities.Keys.ToArray();
        //Calculate new values by the accordance law
        int[] newValues = accordanceFunc(prevValues);
        if (prevValues.Length != newValues.Length)
            throw new ArgumentException("Provided accordance function changes the size of value array");
        //Create accordance dictionary mapping old values to new values
        Dictionary<int, int> accordance = new Dictionary<int, int>();
        for (int i = 0; i < prevValues.Length; i++) {
            accordance[prevValues[i]] = newValues[i];
        }
        return Transform(accordance);
    }

    public RollResult IntervalTransform(params (int left, int right, int newValue)[] intervals) {
        RollResult result = new RollResult();
        foreach (var valProb in _probabilities) {
            var val = valProb.Key;
            var prob = valProb.Value;
            var interval = intervals.FirstOrDefault(i => val >= i.left && val <= i.right);
            if (interval == default)
                continue;
            result.AddProbability(interval.newValue, prob);
        }
        return result;
    }
}
