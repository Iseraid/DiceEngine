namespace DiceEngine
{
    public class DiceRoll {
        private List<Dice> _dicePool = new List<Dice>();

        public DiceRoll() { }

        public DiceRoll(List<Dice> dicePool) {
            _dicePool = dicePool;
        }

        public DiceRoll(Dice dice, int count) {
            for (int i = 0; i < count; i++) {
                _dicePool.Add(dice);
            }
        }

        public void AddDice(Dice dice) {
            _dicePool.Add(dice);
        }

        public void RemoveDice(Dice dice) {
            _dicePool.Remove(dice);
        }

    }
}
