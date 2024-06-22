using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[]? testArr = null;

        // Act & Assert
        Assert.That(() => LongestIncreasingSubsequence.GetLis(testArr), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        // Arrange
        int[] testArr = new int[] { };

        // Act
        string actualResult = LongestIncreasingSubsequence.GetLis(testArr);

        // Assert
        CollectionAssert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        // Arrange
        int[] testArr = new int[] { 3 };

        // Act
        string actualResult = LongestIncreasingSubsequence.GetLis(testArr);

        // Assert
        CollectionAssert.AreEqual("3", actualResult);
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        // Arrange
        int[] testArr = new int[] { 1, -1, 2, 3 , 4, -2, 5, 3  };

        // Act
        string actualResult = LongestIncreasingSubsequence.GetLis(testArr);

        // Assert
        CollectionAssert.AreEqual("1 2 3 4 5", actualResult);
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        // Arrange
        int[] testArr = new int[] { 1, 2 ,3 ,4 ,5 ,6 };

        // Act
        string actualResult = LongestIncreasingSubsequence.GetLis(testArr);

        // Assert
        CollectionAssert.AreEqual("1 2 3 4 5 6", actualResult);
    }
}
