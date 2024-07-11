using NUnit.Framework;

using System;
using System.Linq;

namespace TestApp.UnitTests;

public class ReverseConcatenateTests
{
    
    [Test]
    public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string actualResult = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    
    [Test]
    public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
    {
        // Arrange
        string[] input = new string[] { "test" };
        string expectedResult = "test";

        // Act
        string actualResult = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] input = new string[] { "test", "QA", "Advanced" };
        string expectedResult = "AdvancedQAtest";

        // Act
        string actualResult = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string[]? input = null;

        // Act
        string actualResult = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
    {
        // Arrange
        string[] input = new string[] { "test test", "QA QA ", "Advanced 2 " };
        string expectedResult = "Advanced 2 QA QA test test";

        // Act
        string actualResult = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] input = new string[] { "Programming", "Advanced", "For", "QA", "July"};
        string expectedResult = "JulyQAForAdvancedProgramming";

        // Act
        string actualResult = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
