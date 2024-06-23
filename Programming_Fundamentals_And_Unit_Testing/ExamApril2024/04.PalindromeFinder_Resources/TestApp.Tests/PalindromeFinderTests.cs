using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests;
public class PalindromeFinderTests
{
    [Test]
    public void Test_GetPalindromes_NullWordsList_ReturnsEmptyString()
    {
        // Arrange
        List<string>? words = null;

        // Act
        string actualResult = PalindromeFinder.GetPalindromes(words);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_GetPalindromes_EmptyWordsList_ReturnsEmptyString()
    {
        // Arrange
        List<string> words = new List<string>();

        // Act
        string actualResult = PalindromeFinder.GetPalindromes(words);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_GetPalindromes_ListWithWords_ReturnsOnlyPalidromeWords()
    {
        // Arrange
        List<string> words = new List<string> { "aha", "test", "bob" };
        string expectedResult = "aha bob";

        // Act
        string actualResult = PalindromeFinder.GetPalindromes(words);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetPalindromes_ListWithoutPalindromeWords_ReturnsEmptyString()
    {
        // Arrange
        List<string> words = new List<string> { "test", "exam", "string" };

        // Act
        string actualResult = PalindromeFinder.GetPalindromes(words);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_GetPalindromes_ListOnlyWithPalidromeWords_ReturnsStringWithAllWords()
    {
        // Arrange
        List<string> words = new List<string> { "aha", "oho", "ehe" };
        string expectedResult = "aha oho ehe";

        // Act
        string actualResult = PalindromeFinder.GetPalindromes(words);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
        
    }
}

