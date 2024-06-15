using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        // Arrange
        char[] testArr = new char[] { '0', '1', '2', 'a', 'b', 'c' };

        // Act
        char[] actualResult = Fake.RemoveStringNumbers(testArr);
        char[] expectedResult = new char[] { 'a', 'b', 'c' };
    
        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        char[] testArr = new char[] { 'a', 'b', 'c' };

        // Act
        char[] actualResult = Fake.RemoveStringNumbers(testArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(testArr));
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        char[] testArr = Array.Empty<char>();

        // Act
        char[] actualResult = Fake.RemoveStringNumbers(testArr);
        char[] expectedResult = Array.Empty<char>();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
