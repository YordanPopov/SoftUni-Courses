using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchNamesTests
{
    [Test]
    public void Test_Match_ValidNames_ReturnsMatchedNames()
    {
        // Arrange
        string names = "John Smith and Alice Johnson";
        string expected = "John Smith Alice Johnson";

        // Act
        string actualResult = MatchNames.Match(names);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_NoValidNames_ReturnsEmptyString()
    {
        // Arrange
        string names = "john smith and alice johnson";
        
        // Act
        string actualResult = MatchNames.Match(names);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string names = string.Empty;

        // Act
        string actualResult = MatchNames.Match(names);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }
}
