using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string actualResult = CountCharacters.Count(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new List<string> { "" };

        // Act
        string actualResult = CountCharacters.Count(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string> { "t" };
        string expectedResult = "t -> 1";

        // Act
        string actualResult = CountCharacters.Count(input);

        // Assert
        Assert.That (actualResult, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string> { "test" };
        string expectedResult = "t -> 2" + Environment.NewLine +
                                "e -> 1" + Environment.NewLine +
                                "s -> 1";   

        // Act
        string actualResult = CountCharacters.Count(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string> { "@test!" };
        string expectedResult = "@ -> 1" + Environment.NewLine +
                                "t -> 2" + Environment.NewLine +
                                "e -> 1" + Environment.NewLine +
                                "s -> 1" + Environment.NewLine +
                                "! -> 1";

        // Act
        string actualResult = CountCharacters.Count(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
