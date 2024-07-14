using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string actualResult = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(actualResult, Is.Empty);

    }

   
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] input = new string[] { "apple" };
        string expectedResult = "Plants with 5 letters:" + Environment.NewLine + "apple";

        // Act
        string actualResult = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] input = new string[] { "apple", "orange", "banana" };
        string expectedResult = "Plants with 5 letters:" + Environment.NewLine +
                                "apple" + Environment.NewLine +
                                "Plants with 6 letters:" + Environment.NewLine +
                                "orange" + Environment.NewLine +
                                "banana";

        // Act
        string actualResult = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "aPPle", "OrAnGe", "BANANa" };
        string expectedResult = "Plants with 5 letters:" + Environment.NewLine +
                                "aPPle" + Environment.NewLine +
                                "Plants with 6 letters:" + Environment.NewLine +
                                "OrAnGe" + Environment.NewLine +
                                "BANANa";

        // Act
        string actualResult = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
