using NUnit.Framework;
using System.Security.Cryptography;

namespace TestApp.Tests;

[TestFixture]
public class CamelCaseConverterTests
{
    [Test]
    public void Test_ConvertToCamelCase_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string actualResult = CamelCaseConverter.ConvertToCamelCase(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_ConvertToCamelCase_SingleWord_ReturnsLowercaseWord()
    {
        // Ararnge
        string input = "Test";
        string expectedResult = "test";

        // Act
        string actualResult = CamelCaseConverter.ConvertToCamelCase((string)input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWords_ReturnsCamelCase()
    {
        // Arrange
        string input = "test this case";
        string expectedResult = "testThisCase";

        // Act
        string actualResult = CamelCaseConverter.ConvertToCamelCase(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWordsWithMixedCase_ReturnsCamelCase()
    {
        // Arrange
        string input = "TeSt ThIs CasE";
        string expectedResult = "testThisCase";

        // Act
        string actualResult = CamelCaseConverter.ConvertToCamelCase(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
