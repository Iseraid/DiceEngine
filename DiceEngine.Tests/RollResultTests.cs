using DiceEngine.DiceTools;
using DiceEngine.Utilities;

namespace DiceEngine.Tests;

public class RollResultTests {

    [Test]
    public void RollResultTest_Float_Dictionary_Test() {
        Dice d = Dice.D(20);
        var res = d.Roll();
        TestContext.WriteLine(string.Join(", ", res.Probabilities));
    }

    [Test]
    public void RollResultTest_D10() {
        Dice d = Dice.D(10);
        RollResult res = d.Roll();
        Dictionary<int, float> actual = new Dictionary<int, float>();
        foreach (var side in d.Sides) {
            actual[side] = 1f/10;
            TestContext.WriteLine(actual[side]);
        }
        Assert.That(actual, Is.EqualTo(res.Probabilities).Within(0.00001f));
        /*foreach (var prob in res.Probabilities) {
            Assert.That((float) prob.Value, Is.EqualTo((float) actual[prob.Key]).Within(0.00001f));
        }*/
    }

    [Test]
    public void RollResultTest_2D3() {
        Dice d = Dice.D(3);
        RollResult res1 = d.Roll();
        RollResult res2 = d.Roll();
        RollResult res = res1 + res2;
        TestContext.WriteLine("Result: " + string.Join(", ", res.Probabilities));
        Dictionary<int, float> actual = new Dictionary<int, float> {
            {2, 1f/9 },
            {3, 2f/9 },
            {4, 3f/9 },
            {5, 2f/9 },
            {6, 1f/9 }
        };
        TestContext.WriteLine("Actual: " + string.Join(", ", actual));
        Assert.That(actual, Is.EqualTo(res.Probabilities));//.Within(0.00001f));
    }

    [Test]
    public void RollResultTest_D10_Transform_FuncAccordance() {
        Dice d = Dice.D(10);
        RollResult res = d.Roll().Transform((int[] vals) => {
            int[] newVals = new int[vals.Length];
            for (int i = 0; i < vals.Length; i++) {
                newVals[i] = 1;
                if (vals[i] < 6)
                    newVals[i] = 0;
                if (vals[i] == 1)
                    newVals[i] = -1;
            }
            return newVals;
        });

        TestContext.WriteLine("Result: " + string.Join(", ", res.Probabilities));
        Dictionary<int, float> actual = new Dictionary<int, float> {
            { -1, 1f/10 },
            { 0, 4f/10 },
            { 1, 5f/10 }
        };
        Assert.That(actual, Is.EqualTo(res.Probabilities));//.Within(0.00001f));
    }

    /*[Test]
    public void RollResultTest_D10_Transform_ConditionalAccordance() {
        Dice d = Dice.D(10);
        //RollResult res = d.Roll().Transform()

        TestContext.WriteLine("Result: " + string.Join(", ", res.Probabilities));
        Dictionary<int, float> actual = new Dictionary<int, float> {
            { -1, 0.1f },
            { 0, 0.4f },
            { 1, 0.5f }
        };
        Assert.That(actual, Is.EqualTo(res.Probabilities).Within(0.00001f));
    }*/

    [Test]
    public void TestRollResult_2D10_WOD_Rules() {
        Dice d = Dice.D(10);
        Func<int[], int[]> WODRules = (int[] vals) => {
            int[] newVals = new int[vals.Length];
            for (int i = 0; i < vals.Length; i++) {
                newVals[i] = 1;
                if (vals[i] < 6)
                    newVals[i] = 0;
                if (vals[i] == 1)
                    newVals[i] = -1;
            }
            return newVals;
        };

        RollResult res1 = d.Roll().Transform(WODRules);
        RollResult res2 = d.Roll().Transform(WODRules);
        RollResult res = res1 + res2;
        TestContext.WriteLine("Result: " + string.Join(", ", res.Probabilities));
    }

    [Test]
    public void TestRollResult_GURPS_Rules_3D6_DIFF13() {
        Dice d = Dice.D(6);
        RollResult res1 = d.Roll();
        RollResult res2 = d.Roll();
        RollResult res3 = d.Roll();
        RollResult res4 = res1 + res2 + res3;
        TestContext.WriteLine("Intermidiate result: " + string.Join(", ", res4.Probabilities));
        RollResult res = res4.Transform((int[] vals) => {
            int[] newVals = new int[vals.Length];
            for (int i = 0; i < vals.Length; i++) {
                if (vals[i] == 18)
                    newVals[i] = -1;
                if (vals[i] > 13)
                    newVals[i] = 0;
                if (vals[i] <= 13)
                    newVals[i] = 1;
            }
            return newVals;
        });
        TestContext.WriteLine("Result: " + string.Join(", ", res.Probabilities));
    }

    [Test]
    public void TestRollResult_3D6_With_Utils() {
        var dice = 3 * Dice.D(6);
        var result = dice.Roll().Add();
        TestContext.WriteLine(string.Join(", ", result!.Probabilities));
    }

    [Test]
    public void TestRollResult_Stuff() {
        var res = (10 * Dice.D(10)).Roll().IntervalTransform((1, 1, -1), (2, 5, 0), (6, 10, 1));
        /*for (int i = 0; i < res.Count; i++) {
            res[i] = res[i].IntervalTransform((1, 1, -1), (2, 5, 0), (6, 10, 1));
        }*/
        var result = res.Add();
        result = result.Transform((int[] input) => {
            int[] output = new int[input.Length];
            for (int i = 0; i < input.Length; i++) {
                if (input[i] > 0)
                    output[i] = 1;
                if (input[i] == 0)
                    output[i] = 0;
                if (input[i] < 0)
                    output[i] = -1;
            }
            return output;
        });
        TestContext.WriteLine("Result: " + string.Join(", ", result.Probabilities));
    }
}

