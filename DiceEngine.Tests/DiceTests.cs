namespace DiceEngine.Tests;

public class DiceTests {
    [SetUp]
    public void Setup() {

    }

    [Test]
    public void Multiply_3_D6() {

        var actual = 3 * Dice.D(6);
        var expected = new List<Dice> { Dice.D(6), Dice.D(6), Dice.D(6) };
        Assert.That(actual.Count, Is.EqualTo(expected.Count));
        for (int i = 0; i < expected.Count; i++) {
            Assert.That(actual[i].Value == expected[i].Value);
            
        } 
    }
}