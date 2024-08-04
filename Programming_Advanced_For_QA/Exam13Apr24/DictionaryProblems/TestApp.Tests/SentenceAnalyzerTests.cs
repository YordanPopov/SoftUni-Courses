using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class SentenceAnalyzerTests
{
    [Test]
    public void Test_Analyze_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = string.Empty;

        // Act
        Dictionary<string, int> actualResult = SentenceAnalyzer.Analyze(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Analyze_SingleLetter_ReturnsDictionaryWithSingleLetterEntry()
    {
        // Arrange
        string input = "Z";
        Dictionary<string, int> expectedResult = new()
        {
            ["letters"] = 1
        };

        // Act
        Dictionary<string, int> actualResult = SentenceAnalyzer.Analyze(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Analyze_SingleDigit_ReturnsDictionaryWithSingleDigitEntry()
    {
        // Arrange
        string input = "6";
        Dictionary<string, int> expectedResult = new()
        {
            ["digits"] = 1
        };

        // Act
        Dictionary<string, int> actualResult = SentenceAnalyzer.Analyze(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Analyze_WholeSentence_ReturnsDictionaryWithAllSymbolTypesCount()
    {
        // Arrange
        string input = "ID of the test is 001123523!";
        Dictionary<string, int> expectedResult = new()
        {
            ["letters"] = 13,
            ["digits"] = 9,
            ["special characters"] = 1
        };

        // Act
        Dictionary<string, int> actualResult = SentenceAnalyzer.Analyze(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(3));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

