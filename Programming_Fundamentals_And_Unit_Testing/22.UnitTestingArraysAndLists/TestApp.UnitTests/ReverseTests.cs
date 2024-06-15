using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverseTests
{
    [Test]
    public void Test_ReverseArray_InputIsEmpty_ShouldReturnEmptyString()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();

        // Act
        string result = Reverse.ReverseArray(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    // TODO: finish the test
    [Test]
    public void Test_ReverseArray_InputHasOneElement_ShouldReturnTheSameElement()
    {
        // Arrange
        int[] oneElement = new int[1] { 10 };
        // Act
        string actualResult = Reverse.ReverseArray(oneElement);

        // Assert
        Assert.That(actualResult, Is.EqualTo("10"));
    }

    [TestCase(new int[]{1, 2, 3, 4, 5}, "5 4 3 2 1")]
    [TestCase(new int[]{1, 2}, "2 1")]
    [TestCase(new int[]{1, 2, 2, 1}, "1 2 2 1")]
    [TestCase(new int[]{1, 2, 3, 4, 3, 2, 1}, "1 2 3 4 3 2 1")]
    public void Test_ReverseArray_InputHasMultipleElements_ShouldReturnReversedString(int[] arr, string expectedResult)
    {
        // Arrange

        // Act
        string actualResult = Reverse.ReverseArray(arr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
