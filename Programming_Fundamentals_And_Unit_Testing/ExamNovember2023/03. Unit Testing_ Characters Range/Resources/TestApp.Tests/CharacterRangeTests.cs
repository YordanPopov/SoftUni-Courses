using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class CharacterRangeTests
{
    [Test]
    public void Test_GetRange_WithAAndBInOrder_ReturnsEmptyString()
    {
        // Arrange
        char ch1 = 'A';
        char ch2 = 'B';

        // Act
        string actualResult = CharacterRange.GetRange(ch1, ch2);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_GetRange_WithBAndAInOrder_ReturnsEmptyString()
    {
        // Arrange
        char ch1 = 'B';
        char ch2 = 'A';

        // Act
        string actualResult = CharacterRange.GetRange(ch1, ch2);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_GetRange_WithAAndCInOrder_ReturnsB()
    {
        // Arrange
        char ch1 = 'A';
        char ch2 = 'C';
        string expectedResult = "B";

        // Act
        string actualResult = CharacterRange.GetRange(ch1, ch2);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetRange_WithDAndGInOrder_Returns_E_F()
    {
        // Arrange
        char ch1 = 'D';
        char ch2 = 'G';
        string expectedResult = "E F";

        // Act
        string actualResult = CharacterRange.GetRange(ch1, ch2);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y()
    {
        // Arrange
        char ch1 = 'X';
        char ch2 = 'Z';
        string expectedResult = "Y";

        // Act
        string actualResult = CharacterRange.GetRange(ch1, ch2);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
