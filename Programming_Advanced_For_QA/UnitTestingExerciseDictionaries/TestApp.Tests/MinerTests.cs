using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string actualResult = Miner.Mine(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = { "Gold 200", "GOLD 200", "GoLd 15" };
        string expectedResult = "gold -> 415";

        // Act
        string actualResult = Miner.Mine(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] input = { "gold 200", "silver 15", "gold 200", "silver 15" };
        string expectedResult = "gold -> 400" + Environment.NewLine +
                                "silver -> 30";

        // Act
        string actualResult = Miner.Mine(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
