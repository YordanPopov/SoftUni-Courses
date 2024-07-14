using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestApp.Tests;

public class GroupingTests
{
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> nums = new List<int>();

        // Act
        string actualResult = Grouping.GroupNumbers(nums);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string expectedResult = "Odd numbers: 1, 3, 5, 7, 9" + Environment.NewLine +
                                "Even numbers: 2, 4, 6, 8, 10";

        // Act
        string actualResult = Grouping.GroupNumbers(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int> { 2, 4, 6, 8, 10};
        string expectedResult = "Even numbers: 2, 4, 6, 8, 10";

        // Act
        string actualResult = Grouping.GroupNumbers(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int> { 1, 3, 5, 7, 9 };
        string expectedResult = "Odd numbers: 1, 3, 5, 7, 9";

        // Act
        string actualResult = Grouping.GroupNumbers(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int> { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
        string expectedResult = "Odd numbers: -1, -3, -5, -7, -9" + Environment.NewLine +
                                "Even numbers: -2, -4, -6, -8, -10";

        // Act
        string actualResult = Grouping.GroupNumbers(nums);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
