using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string actualResult = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        // Arrange
        string[] input = new string[] { "abc" };
        string expectedResult = "abcabcabc";

        // Act
        string actualResult = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrange
        string[] input = new string[] { "test", "QA", "Adv", "ab", "a" };
        string expectedResult = "testtesttesttestQAQAAdvAdvAdvababa";

        // Act
        string actualResult = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
