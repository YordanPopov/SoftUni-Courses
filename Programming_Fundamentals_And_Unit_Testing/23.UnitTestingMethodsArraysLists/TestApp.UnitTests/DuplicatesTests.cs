using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class DuplicatesTests
{
    [Test]
    public void Test_RemoveDuplicates_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();

        // Act
        int[] actualResult = Duplicates.RemoveDuplicates(numbers);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_RemoveDuplicates_NoDuplicates_ReturnsOriginalArray()
    {
        // Arrange
        int[] noDuplicateArr = new int[3] { 1, 2, 3 };

        // Act
        int[] actualResult = Duplicates.RemoveDuplicates(noDuplicateArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(noDuplicateArr));
    }

    [Test]
    public void Test_RemoveDuplicates_SomeDuplicates_ReturnsUniqueArray()
    {
        // Arrange
        int[] duplicateArr = new int[] { 1, 2, 4, 4, 3};

        // Act
        int[] actualResult = Duplicates.RemoveDuplicates(duplicateArr);
        int[] expectedResult = new int[] { 1, 2, 4, 3};

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_RemoveDuplicates_AllDuplicates_ReturnsSingleElementArray()
    {
        int[] duplicateArr = new int[] { 1, 1, 1, 1, 1};

        // Act
        int[] actualResult = Duplicates.RemoveDuplicates(duplicateArr);
        int[] expectedResult = new int[] { 1 };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
