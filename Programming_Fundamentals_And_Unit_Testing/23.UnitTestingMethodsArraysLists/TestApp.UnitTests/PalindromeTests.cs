using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PalindromeTests
{
    [Test]
    public void Test_IsPalindrome_ValidPalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> word = new List<string> { "ese", "aha" };

        // Act
        bool actualResult = Palindrome.IsPalindrome(word);

        // Assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Test_IsPalindrome_EmptyList_ReturnsTrue()
    {
        // Arrange
        List<string> emptyList = new List<string>();

        // Act
        bool actualResult = Palindrome.IsPalindrome(emptyList);

        // Assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Test_IsPalindrome_SingleWord_ReturnsTrue()
    {
        // Arrange
        List<string> word = new List<string> { "ese" };

        // Act
        bool actualResult = Palindrome.IsPalindrome(word);

        // Assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Test_IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        // Arrange
        List<string> word = new List<string> { "test" };

        // Act
        bool actualResult = Palindrome.IsPalindrome(word);

        // Assert
        Assert.That(actualResult, Is.False);
    }

    [Test]
    public void Test_IsPalindrome_MixedCasePalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> word = new List<string> { "Ese", "Oko", "Sos" };

        // Act
        bool actualResult = Palindrome.IsPalindrome(word);

        // Assert
        Assert.That(actualResult, Is.True);
    }
}
