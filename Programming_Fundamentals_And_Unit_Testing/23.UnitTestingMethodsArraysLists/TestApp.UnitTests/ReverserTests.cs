using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverserTests
{
    [Test]
    public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        string[] inputArray = Array.Empty<string>();

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
    {
        // Arrange
        string[] stringArr = new string[1] { "Hello" };

        // Act
        string[] actualResult = Reverser.ReverseStrings(stringArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(new[] { "olleH" }));
    }

    [Test]
    public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
    {
        // Arrange
        string[] multiStringArr = new string[3] { "Hello" , "John", "Wick"};

        // Act
        string[] actualResult = Reverser.ReverseStrings(multiStringArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(new[] { "olleH", "nhoJ", "kciW" }));
    }

    [Test]
    public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
    {
        // Arrange
        string[] multiStringArr = new string[2] { "@abv!", "!abv@"};

        // Act
        string[] actualResult = Reverser.ReverseStrings(multiStringArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(new[] { "!vba@", "@vba!" }));
    }
}
