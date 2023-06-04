namespace DiceEngine.Utilities;
public static class Utils {
    /// <summary>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>Greatest common divisor</returns>
    public static int GCD(int a, int b) {
        if (a == 0) {
            return b;
        } else {
            var min = Math.Min(a, b);
            var max = Math.Max(a, b);
            //вызываем метод с новыми аргументами
            return GCD(max % min, min);
        }
    }
}
