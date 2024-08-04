using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DivisibilityTransformatorTest
{
    [Test]
    public void Test_Transform_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string actualResult = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Transform_InvalidValues_ReturnsEmptyString()
    {
        // Arrange
        string input = "one 1.5 two 2.5 three";

        // Act
        string actualResult = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Transform_ValidValues_ReturnsTransformedValues()
    {
        // Arrange
        string input = "12 15 8";
        string expectedResutl = "2 7.5 64";

        // Act
        string actualResult = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResutl));
    }

    [Test]
    public void Test_Transform_ZeroOrNotDivisibleValues_ReturnsSameValues()
    {
        // Arrange
        string input = "7 23 0";
        string expectedResult = "7 23 0";

        // Act
        string actualResult = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

