using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;
        int positions = 5;

        // Act
        string actualResult = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        // Arrange
        string input = "123456";
        int positions = 0;

        // Act
        string actualResult = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.That(actualResult, Is.EqualTo("123456"));
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "123456";
        int positions = 3;

        // Act
        string actualResult = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.That(actualResult, Is.EqualTo("456123"));
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "123456";
        int positions = -2;

        // Act
        string actualResult = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.That(actualResult, Is.EqualTo("561234"));
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        // Arrange
        string input = "123456";
        int positions = input.Length + 1;

        // Act
        string actualResult = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.That(actualResult, Is.EqualTo("612345"));
    }
}
