using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class EvenOddSubtractionTests
{
    [Test]
    public void Test_FindDifference_InputIsEmpty_ShouldReturnZero()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();

        // Act
        int result = EvenOddSubtraction.FindDifference(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    // TODO: finish the test
    [Test]
    public void Test_FindDifference_InputHasOnlyEvenNumbers_ShouldReturnEvenSum()
    {
        // Arrange
        int[] evenArr = new int[] { 2, 8 };
        // Act
        int actualResult = EvenOddSubtraction.FindDifference(evenArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(10));
    }

    [Test]
    public void Test_FindDifference_InputHasOnlyOddNumbers_ShouldReturnNegativeOddSum()
    {
        // Arrange
        int[] oddArr = new int[] { 1, 9 };

        // Act
        int actualResult = EvenOddSubtraction.FindDifference(oddArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(-10));
    }

    [Test]
    public void Test_FindDifference_InputHasMixedNumbers_ShouldReturnDifference()
    {
        // Arrange
        int[] mixedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        // Act
        int actualResult = EvenOddSubtraction.FindDifference(mixedArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(5));
    }
}
