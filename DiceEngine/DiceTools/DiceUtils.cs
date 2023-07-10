namespace DiceEngine.DiceTools;
public static class DiceUtils {

    /// <summary>
    /// Rolls the specified dice.
    /// </summary>
    /// <param name="dice">Dice to roll.</param>
    /// <returns>Result of the roll.</returns>
    public static RollResult Roll(this Dice dice) {
        return new RollResult(dice);
    }

    /// <summary>
    /// Rolls the supplied list of dice.
    /// </summary>
    /// <param name="diceList">Dice to roll.</param>
    /// <returns>List of roll results.</returns>
    public static List<RollResult> Roll(this List<Dice> diceList) {
        return diceList.Select(d => d.Roll()).ToList();
    }

    /// <summary>
    /// Adds up roll results from the supplied list.
    /// </summary>
    /// <param name="rollResults">List of results for addition.</param>
    /// <returns>Addition result for the supplied roll results.</returns>
    public static RollResult Add(this List<RollResult> rollResults) {
        if (rollResults.Count == 0)
            throw new InvalidOperationException("List of roll results must contain at least one element.");
        var result = rollResults[0];
        for (int i = 1; i < rollResults.Count; i++) {
            result += rollResults[i];
        }
        return result;
    }

    public static List<RollResult> IntervalTransform(this List<RollResult> rollResults, params (int left, int right, int newValue)[] intervals) {
        return rollResults.Select(res => res.IntervalTransform(intervals)).ToList();
    }
}

