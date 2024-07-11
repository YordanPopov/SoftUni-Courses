using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchDatesTests
{
 
    [Test]
    public void Test_Match_ValidDate_ReturnsExpectedResult()
    {
        // Arrange
        string input = "31.Dec.2022 lo.rem.ipsu";
        string expectedResult = "Day: 31, Month: Dec, Year: 2022";

        // Act
        string actualResult = MatchDates.Match(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Match_NoMatch_ReturnsEmptyString()
    {
        // Arrange
        string input = "Invalid date format";

        // Act
        string actualResult = MatchDates.Match(input);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_Match_MultipleMatches_ReturnsFirstMatch()
    {
        // Arrange
        string input = @"31.Dec.2022 16-Jan-2022 17/Dec/2021 18\Dec\2022";
        string expectedResult = "Day: 31, Month: Dec, Year: 2022";

        // Act
        string actualResult = MatchDates.Match(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Match_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string actualResult = MatchDates.Match(input);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_Match_NullInput_ThrowsArgumentException()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.That(() => MatchDates.Match(input), Throws.ArgumentException);
    }
}
