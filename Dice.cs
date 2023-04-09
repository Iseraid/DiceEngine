namespace DiceEngine
{
    public class Dice
    {
        protected int[] _sides;
        public int SideCount => _sides.Length;
        public int Value { get; private set; }

        public Dice(int[] sides) {
            _sides = sides;
        }

        public int Roll() {
            Random rnd = new Random();
            var index = rnd.Next(SideCount);
            Value = _sides[index];
            return Value;
        }
    }
}
