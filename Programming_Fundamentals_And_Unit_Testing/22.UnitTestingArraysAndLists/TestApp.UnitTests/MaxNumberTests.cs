using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MaxNumberTests
{

    [Test]
    public void Test_FindMax_InputHasOneElement_ShouldReturnTheElement()
    {
        // Arrange
        List<int> OneElement = new List<int> { 100 };

        // Act
        int actualResult = MaxNumber.FindMax(OneElement);

        // Assert
        Assert.That(actualResult, Is.EqualTo(100));
    }

    [Test]
    public void Test_FindMax_InputHasPositiveIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> OneElement = new List<int> { 100, 10, 20, 30, 50, 70, 99 };

        // Act
        int actualResult = MaxNumber.FindMax(OneElement);

        // Assert
        Assert.That(actualResult, Is.EqualTo(100));
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> OneElement = new List<int> { -100, -99, -50, -46, -2, -1 };

        // Act
        int actualResult = MaxNumber.FindMax(OneElement);

        // Assert
        Assert.That(actualResult, Is.EqualTo(-1));
    }

    [Test]
    public void Test_FindMax_InputHasMixedIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> OneElement = new List<int> { -100, -99, -50, 0, 50, 99, 100 };

        // Act
        int actualResult = MaxNumber.FindMax(OneElement);

        // Assert
        Assert.That(actualResult, Is.EqualTo(100));
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateMaxValue_ShouldReturnMaximum()
    {
        // Arrange
        List<int> OneElement = new List<int> { 100, 10, 20, 30, 50, 70, 99, 99, 98, 98, 100, 100, 100 };

        // Act
        int actualResult = MaxNumber.FindMax(OneElement);

        // Assert
        Assert.That(actualResult, Is.EqualTo(100));
    }
}
