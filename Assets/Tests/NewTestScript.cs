using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual(4, 3);
    }

    [TestCase(1, 1, ExpectedResult = 2)]
    [TestCase(0, 0, ExpectedResult = 0)]
    [TestCase(1, 0, ExpectedResult = 10)]
    public int Sum(int first, int second)
    {
        return first + second;
    }

    [Test, Combinatorial]
    public void TestMethod(
    [Values(0, 1, 2)] int id,
    [Values("X", "Y")] string c)
    {    
        // ...
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
