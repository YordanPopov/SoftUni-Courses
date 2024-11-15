using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

public class DigitAndSymbolCounterTests
{

    [Test]
    public void Test_EmptyStringInput_ReturnsEmptyDictionary()
    {
        string input = string.Empty;

        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_NoDigitsStringInput_ReturnsOnlyNonDigitsCount()
    {
        string input = "Hello World";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["non-digit symbol"] = 11
        };

        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_NoOddDigitsStringInput_ReturnsOnlyEvenDigitsAndNonDigitsCount()
    {
        string input = "2468XYZ";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["even digit"] = 4,
            ["non-digit symbol"] = 3
        };

        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_NoEvenDigitsStringInput_ReturnsOnlyOddDigitsAndNonDigitsCount()
    {
        string input = "QA is cool 579?";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["odd digit"] = 3,
            ["non-digit symbol"] = 12
        };

        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_SymbolsEvenAndOddDigitsStringInput_ReturnsAllTypeOfCounts()
    {
        string input = "123abc!";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["even digit"] = 1,
            ["odd digit"] = 2,
            ["non-digit symbol"] = 4
        };

        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}