using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[] { "Test" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown fox jumps over the lazy dog";

        // Act
        string actualResult = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
        
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWords = new string[] { "dog", "fox" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown *** jumps over the lazy ***";

        // Act
        string actualResult = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = Array.Empty<string>();
        string text = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown fox jumps over the lazy dog";

        // Act
        string actualResult = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] bannedWords = new string[] { "fox jumps", "over" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown ********* **** the lazy dog";

        // Act
        string actualResult = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
