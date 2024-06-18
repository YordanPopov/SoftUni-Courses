using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, "5 5 13 13")]
    [TestCase(new int[] { -1, -2, -3, -4, -5, -6, -7, -8 }, "-5 -5 -13 -13")]
    [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, "0 0 0 0")]
    [TestCase(new int[] { }, "")]
    [TestCase(new int[] { 1, 2, 0, 0, 0, 0, 7, 8}, "2 1 8 7")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        // Arrange

        // Act
        string actualResult = FoldSum.FoldArray(arr);

        // Assert
        Assert.AreEqual(expected, actualResult);
    }
}
