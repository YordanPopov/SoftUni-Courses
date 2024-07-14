using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        string actualResult = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { 10 };
        string expectedResult = "10 -> 1";

        // Act
        string actualResult = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { 1, 10, 10, 50, 1, 100 };
        string expectedResult = "1 -> 2" + Environment.NewLine +
                                "10 -> 2" + Environment.NewLine +
                                "50 -> 1" + Environment.NewLine +
                                "100 -> 1";

        // Act
        string actualResult = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { -1, -10, -10, -50, -1, -100 };
        string expectedResult = "-100 -> 1" + Environment.NewLine +
                                "-50 -> 1" + Environment.NewLine +
                                "-10 -> 2" + Environment.NewLine +
                                "-1 -> 2";

        // Act
        string actualResult = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { 1, 0, 1, 0, 0, 2 };
        string expectedResult = "0 -> 3" + Environment.NewLine +
                                "1 -> 2" + Environment.NewLine +
                                "2 -> 1";

        // Act
        string actualResult = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
