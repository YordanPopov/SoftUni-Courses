using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class VowelsAndConsonantsCounterTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string sentence = string.Empty;
        Dictionary<string, int> expectedResult = new Dictionary<string, int>();
 
        // Act
        Dictionary<string, int> actualResult = VowelsAndConsonantsCounter.AnalyzeSentence(sentence);

        // Assert
        Assert.That(actualResult, Is.Empty);
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyVowelsRichWords_ReturnsDictionaryWithVowelsRichWordsOnly()
    {
        // Arrange
        string sentence = "Alo, alo";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["vowel-rich"] = 2
        };

        // Act
        Dictionary<string, int> actualResult = VowelsAndConsonantsCounter.AnalyzeSentence(sentence);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult, Contains.Key("vowel-rich"));
        Assert.IsFalse(actualResult.ContainsKey("consonant-rich"));
        Assert.IsFalse(actualResult.ContainsKey("balanced"));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyConsonantsRichWords_ReturnsDictionaryWithConsonantsRichWordsOnly()
    {
        // Arrange
        string sentence = "Hello World";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["consonant-rich"] = 2
        };

        // Act
        Dictionary<string, int> actualResult = VowelsAndConsonantsCounter.AnalyzeSentence(sentence);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult, Contains.Key("consonant-rich"));
        Assert.IsFalse(actualResult.ContainsKey("vowel-rich"));
        Assert.IsFalse(actualResult.ContainsKey("balanced"));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyBalancedWords_ReturnsDictionaryWithBalancedWordsOnly()
    {
        // Arrange
        string sentence = "QA is cool";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["balanced"] = 3
        };

        // Act
        Dictionary<string, int> actualResult = VowelsAndConsonantsCounter.AnalyzeSentence(sentence);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult, Contains.Key("balanced"));
        Assert.IsFalse(actualResult.ContainsKey("vowel-rich"));
        Assert.IsFalse(actualResult.ContainsKey("consonant-rich"));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AnalyzeSentence_AllTypeOfWords_ReturnsDictionaryWithAllTypeOfEntries()
    {
        // Arrange
        string sentence = "The QA is awesome choice";
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["consonant-rich"] = 1,
            ["vowel-rich"] = 1,
            ["balanced"] = 3
        };

        // Act
        Dictionary<string, int> actualResult = VowelsAndConsonantsCounter.AnalyzeSentence(sentence);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(3));
        Assert.That(actualResult, Contains.Key("balanced"));
        Assert.That(actualResult, Contains.Key("consonant-rich"));
        Assert.That(actualResult, Contains.Key("vowel-rich"));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

