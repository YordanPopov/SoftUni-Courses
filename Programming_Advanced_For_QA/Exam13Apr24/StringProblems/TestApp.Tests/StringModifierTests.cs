using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringModifierTests
{
    [Test]
    public void Test_Modify_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string actualResult = StringModifier.Modify(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Modify_SingleWordWithEvenLength_ReturnsUppperCaseWord()
    {
        // Arrange
        string input = "test";
        string expectedResult = "TEST";

        // Act
        string actualResult = StringModifier.Modify(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Modify_SingleWordWithOddLength_ReturnsToLowerCaseWord()
    {
        // Arrange
        string input = "SOFTUNI";
        string expectedResult = "softuni";

        // Act
        string actualResult = StringModifier.Modify(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Modify_MultipleWords_ReturnsModifiedString()
    {
        // Arrange
        string input = "test ThIs SOfTuni";
        string expectedResult = "TEST THIS softuni";

        // Act
        string actualResult = StringModifier.Modify(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

