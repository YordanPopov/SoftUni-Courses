using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string actualResult = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = new string[] { "test", "qa", "qa", "test" };

        // Act
        string actualResult = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] input = new string[] { "test", "qa", "advanced", "qa", "test" };
        string expectedResult = "advanced";

        // Act
        string actualResult = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] input = new string[] { "test", "qa", "advanced", "qa", "qest", "qest", "qa", "qa", "qa" };
        string expectedResult = "test qa advanced";

        // Act
        string actualResult = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "tEsT", "Qa", "AdvaNced", "qA", "TesT", "tESt", "QA", "qa", "qA" };
        string expectedResult = "test qa advanced";

        // Act
        string actualResult = OddOccurrences.FindOdd(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
