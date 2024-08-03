using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class AcronymGeneratorTests
{
    [Test]
    public void Test_GenerateAcronym_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string actualResult = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_GenerateAcronym_SingleWord_ReturnsUpperCaseFirstLetter()
    {
        // Arrange
        string input = "test";
        string expectedResult = "T";

        // Act
        string actualResult = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GenerateAcronym_MultipleWords_ReturnsUpperCaseFirstLetters()
    {
        // Arrange
        string input = "united states of America";
        string expectedResult = "USA";

        // Act
        string actualResult = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GenerateAcronym_WordsWithNonLetters_ReturnsAcronymWithoutNonLetters()
    {
        // Arrange
        string input = "1234 hello world";
        string expectedResult = "HW";

        // Act
        string actualResult = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GenerateAcronym_PhraseWithSpecialCharacters_ReturnsUpperCaseFirstLetters()
    {
        // Arrange
        string input = "hello! wordl!";
        string expectedResult = "HW";

        // Act
        string actualResult = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
