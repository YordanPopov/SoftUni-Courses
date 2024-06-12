using NUnit.Framework;

namespace TestApp.UnitTests;

public class StringReverseTests
{
    // TODO: finish test
    [Test]
    public void Test_Reverse_WhenGivenEmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string actualResult = StringReverse.Reverse(input);
        string expectedResult = string.Empty;

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_Reverse_WhenGivenSingleCharacterString_ReturnsSameCharacter()
    {
        // Arrange
        string input = "X";

        // Act
        string actualResult = StringReverse.Reverse(input);
        string expectedResult = "X";

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalString_ReturnsReversedString()
    {
        // Arrange
        string input = "lebed";

        // Act
        string actualResult = StringReverse.Reverse(input);
        string expectedResult = "debel";

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}
