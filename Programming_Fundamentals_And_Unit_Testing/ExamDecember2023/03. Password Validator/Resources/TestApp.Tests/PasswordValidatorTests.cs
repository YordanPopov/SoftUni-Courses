using NUnit.Framework;

namespace TestApp.Tests;

public class PasswordValidatorTests
{
    [Test]
    public void Test_CheckPassword_ValidPassword_ReturnsValidMessage()
    {
        // Arrange
        string validPassword = "Pass123";
        string expectedResult = "Password is valid";

        // Act
        string actualResult = PasswordValidator.CheckPassword(validPassword);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CheckPassword_PasswordTooShort_ReturnsErrorMessage()
    {
        // Arrange
        string validPassword = "Pas12";
        string expectedResult = "Password must be between 6 and 10 characters";

        // Act
        string actualResult = PasswordValidator.CheckPassword(validPassword);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CheckPassword_ContainsSpecialCharacters_ReturnsErrorMessage()
    {
        // Arrange
        string validPassword = "Test@123";
        string expectedResult = "Password must consist only of letters and digits";

        // Act
        string actualResult = PasswordValidator.CheckPassword(validPassword);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CheckPassword_InsufficientDigits_ReturnsErrorMessage()
    {
        // Arrange
        string validPassword = "TestTest";
        string expectedResult = "Password must have at least 2 digits";

        // Act
        string actualResult = PasswordValidator.CheckPassword(validPassword);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CheckPassword_ValidPasswordWithMaximumLength_ReturnsValidMessage()
    {
        // Arrange
        string validPassword = "Pass123Pas";
        string expectedResult = "Password is valid";

        // Act
        string actualResult = PasswordValidator.CheckPassword(validPassword);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
