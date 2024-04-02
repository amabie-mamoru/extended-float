using NUnit.Framework;
using com.amabie.ExtendedFloat;

public class ExtendedFloatRuntimeTest
{
    [Test]
    public void AddTest()
    {
        var result = new ExtendedFloat(1) + new ExtendedFloat(1);
        var expected = new ExtendedFloat(2);
        Assert.AreEqual(expected.ToString(), result.ToString());
        result = new ExtendedFloat(0.01) + new ExtendedFloat(1.101);
        expected = new ExtendedFloat(1.111);
        Assert.AreEqual(expected.ToString(), result.ToString());
    }
}
