using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class GaussTrickTests
{
    [Test]
    public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        List<int> result = GaussTrick.SumPairs(emptyList);

        // Assert
        CollectionAssert.AreEqual(emptyList, result);
    }

    [Test]
    public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
    {
        // Arrange
        List<int> oneElement = new List<int> { 10 };

        // Act
        List<int> actualResult = GaussTrick.SumPairs(oneElement);

        // Assert
        CollectionAssert.AreEqual(oneElement, actualResult);
    }

    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> evenList = new List<int> { 1, 2, 3, 4 };

        // Act
        List<int> actualResult = GaussTrick.SumPairs(evenList);
        List<int> expectedResult = new List<int> { 5, 5 };

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> oddList = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        List<int> actualResult = GaussTrick.SumPairs(oddList);
        List<int> expectedResult = new List<int> { 6, 6, 3 };

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> oddList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        // Act
        List<int> actualResult = GaussTrick.SumPairs(oddList);
        List<int> expectedResult = new List<int> { 11, 11, 11, 11, 11 };

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> oddList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        // Act
        List<int> actualResult = GaussTrick.SumPairs(oddList);
        List<int> expectedResult = new List<int> {14, 14, 14, 14, 14, 14, 7};

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}
