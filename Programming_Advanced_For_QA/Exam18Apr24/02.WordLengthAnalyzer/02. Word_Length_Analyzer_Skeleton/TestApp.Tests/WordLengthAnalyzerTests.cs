using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class WordLengthAnalyzerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange 
        string input = string.Empty;

        // Act
        Dictionary<string, int> actualResult = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_AnalyzeSentence_InvalidWordsWithDigits_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = "0n3 2 D1g1ts";

        // Act
        Dictionary<string, int> actualResult = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_AnalyzeSentence_WordsWithDifferentThanLetterSymbols_ReturnsDictionaryOnlyWithValidWordTypesCount()
    {
        // Arrange
        string input = "Valid Inval1d w0rds";

        Dictionary<string, int> expectedResult = new()
        {
            ["medium"] = 1
        };

        // Act
        Dictionary<string, int> actualResult = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_AnalyzeSentence_WholeSentenceWithValidWords_ReturnsAllTypeOfWordsWithCorrectCount()
    {
        // Arrange
        string input = "Quality assurance courses of SoftUni are the best!";

        Dictionary<string, int> expectedResult = new()
        {
            ["short"] = 4,
            ["medium"] = 3,
            ["long"] = 1
        };

        // Act
        Dictionary<string, int> actualResult = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(3));
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}

