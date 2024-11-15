using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace TestApp.Tests;

public class LetterTypeCounterTests
{
    [Test]
    public void Test_CountLetterTypes_EmptyString_ReturnEmptyDictionary()
    {
        string input = string.Empty;

        Dictionary<string, int> actualResult = LetterTypeCounter.CountLetterTypes(input);

        Assert.IsEmpty(actualResult);

    }

    [Test]
    public void Test_CountLetterTypes_NonLetterString_ReturnNonLetterCountOnly()
    {
        string input = "!@ 123 %";

        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["non-letter"] = 8
        };

        Dictionary<string, int> actualResult = LetterTypeCounter.CountLetterTypes(input);

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_CountLetterTypes_NoOddLetterString_ReturnEvenAndNonLetterCount()
    {
        string input = "@358BZf";

        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["even letter"] = 3,
            ["non-letter"] = 4
        };

        Dictionary<string, int> actualResult = LetterTypeCounter.CountLetterTypes(input);

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_CountLetterTypes_NoEvenLetterString_ReturnOddAndNonLetterCount()
    {
        string input = "QA is coo1!!!";

        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["odd letter"] = 7,
            ["non-letter"] = 6
        };

        Dictionary<string, int> actualResult = LetterTypeCounter.CountLetterTypes(input);

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_CountLetterTypes_AllTypeOfLetterString_ReturnEvenOddAndNonLetterCount()
    {
        string input = "123abc!";

        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["even letter"] = 1,
            ["odd letter"] = 2,
            ["non-letter"] = 4
        };

        Dictionary<string, int> actualResult = LetterTypeCounter.CountLetterTypes(input);

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}
