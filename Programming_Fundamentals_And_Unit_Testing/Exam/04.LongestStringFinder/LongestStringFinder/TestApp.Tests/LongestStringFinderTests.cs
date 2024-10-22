using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class LongestStringFinderTests
{

    [Test]
    public void Test_GetLongestString_EmptyList_ReturnsEmptyString()
    {
        List<string> emptyList = new List<string>();

        string result = LongestStringFinder.GetLongestString(emptyList);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_GetLongestString_NullList_ReturnsEmptyString()
    {
        List<string> nullList = null;

        string result = LongestStringFinder.GetLongestString(nullList);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_GetLongestString_OneElementInList_ReturnsThisWordAsString()
    {
        List<string> oneWordList = new List<string>() { "test"};

        string result = LongestStringFinder.GetLongestString(oneWordList);

        Assert.That(result, Is.EqualTo("test"));
    }

    [Test]
    public void Test_GetLongestString_ManyWordWithDiffrentLength_ReturnsLongestWord()
    {
        List<string> oneWordList = new List<string>() { "a", "dddd", "ccc", "bb", "fffff" };

        string result = LongestStringFinder.GetLongestString(oneWordList);

        Assert.That(result, Is.EqualTo("fffff"));
    }

    [Test]
    public void Test_GetLongestString_ManyWordWithSameLength_ReturnsFirstWordOfThem()
    {
        List<string> oneWordList = new List<string>() { "a", "dddd", "cccc", "bbbb", "ffff" };

        string result = LongestStringFinder.GetLongestString(oneWordList);

        Assert.That(result, Is.EqualTo("dddd"));
    }
}
