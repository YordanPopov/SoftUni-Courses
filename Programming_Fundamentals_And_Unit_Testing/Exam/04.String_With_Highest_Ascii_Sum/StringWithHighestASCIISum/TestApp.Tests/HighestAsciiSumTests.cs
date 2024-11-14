using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class HighestAsciiSumTests
{

    [Test]
    public void Test_FindStringWithHighestAsciiSum_EmptyList_ReturnsEmptyString()
    {
       List<string> list = new List<string>();

        string result = HighestAsciiSum.FindStringWithHighestAsciiSum(list);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_FindStringWithHighestAsciiSum_NullList_ReturnsEmptyString()
    {
        List<string> list = null;

        string result = HighestAsciiSum.FindStringWithHighestAsciiSum(list);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_FindStringWithHighestAsciiSum_OneElementInList_ReturnsThisString()
    {
        List<string> list = new List<string> { "aaa" };

        string result = HighestAsciiSum.FindStringWithHighestAsciiSum(list);

        Assert.That(result, Is.EqualTo("aaa"));
    }

    [Test]
    public void Test_FindStringWithHighestAsciiSum_ManyElemenstInList_ReturnsHighestAsciiSumString()
    {
        List<string> list = new List<string> { "aaa", "bbb", "ddd", "fff", "ccc" };

        string result = HighestAsciiSum.FindStringWithHighestAsciiSum(list);

        Assert.That(result, Is.EqualTo("fff"));
    }

    [Test]
    public void Test_FindStringWithHighestAsciiSum_ManyEqualValueStrings_ReturnsFirstString()
    {
        List<string> list = new List<string> { "bbb", "bbb", "bbb", "bbb", "bbb", "bbb", "bbb" };

        string result = HighestAsciiSum.FindStringWithHighestAsciiSum(list);

        Assert.That(result, Is.EqualTo("bbb"));
    }
}
