using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class AdjacentEqualTests
{
    [Test]
    public void Test_Sum_InputIsEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> emptyList = new List<int>();

        // Act
        string actualResult = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.That(actualResult, Is.EqualTo(""));
    }

    [Test]
    public void Test_Sum_NoAdjacentEqualNumbers_ShouldReturnOriginalList()
    {
        // Arrange
        List<int> noAdjacentNumbers = new List<int> { 1, 2, 3, 4 ,5 };

        // Act
        string actualResult = AdjacentEqual.Sum(noAdjacentNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo("1 2 3 4 5"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersExist_ShouldReturnSummedList()
    {
        // Arrange
        List<int> adjacentNumbers = new List<int> { 1, 2, 2, 5, 6 };

        // Act
        string actualResult = AdjacentEqual.Sum(adjacentNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo("1 4 5 6"));
    }

    [Test]
    public void Test_Sum_AllNumbersAreAdjacentEqual_ShouldReturnSingleSummedNumber()
    {
        // Arrange
        List<int> adjacentNumbers = new List<int> { 2, 2};

        // Act
        string actualResult = AdjacentEqual.Sum(adjacentNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo("4"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtBeginning_ShouldReturnSummedList()
    {
        // Arrange
        List<int> adjacentNumbers = new List<int> { 2, 2, 5, 6, 7};

        // Act
        string actualResult = AdjacentEqual.Sum(adjacentNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo("4 5 6 7"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtEnd_ShouldReturnSummedList()
    {
        // Arrange
        List<int> adjacentNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 6};

        // Act
        string actualResult = AdjacentEqual.Sum(adjacentNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo("1 2 3 4 5 12"));
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersInMiddle_ShouldReturnSummedList()
    {
        // Arrange
        List<int> adjacentNumbers = new List<int> { 1, 2, 3, 3, 4, 5, 6 };

        // Act
        string actualResult = AdjacentEqual.Sum(adjacentNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo("1 2 6 4 5 6"));
    }
}
