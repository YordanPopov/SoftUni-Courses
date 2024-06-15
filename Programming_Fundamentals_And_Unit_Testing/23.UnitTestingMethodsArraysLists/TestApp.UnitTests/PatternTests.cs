using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        // Arrange
        int[] testArr = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };

        // Act
        int[] actualResult = Pattern.SortInPattern(testArr);
        int[] expectedResult = new int[] { 1, 5, 2, 4, 3 };

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] testArr = Array.Empty<int>();

        // Act
        int[] actualResult = Pattern.SortInPattern(testArr);
        int[] expectedResult = Array.Empty<int>();

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        // Arrange
        int[] testArr = new int[] { 100 };

        // Act
        int[] actualResult = Pattern.SortInPattern(testArr);
        int[] expectedResult = new int[] { 100 };

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}
