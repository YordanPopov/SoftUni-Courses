using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailTests
{
    // TODO: finish test
    [Test]
    public void Test_IsValidEmail_ValidEmail()
    {
        // Arrange
        string validEmail = "test@example.com";

        // Act
        bool actualResult = Email.IsValidEmail(validEmail);

        // Assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Test_IsValidEmail_InvalidEmail()
    {
        // Arrange
        string invalidEmail = "testexamplecom";

        // Act
        bool actualResult = Email.IsValidEmail(invalidEmail);

        // Assert
        Assert.That(actualResult, Is.False);
    }

    [TestCase("", false)]
    [TestCase("     ", false)]
    public void Test_IsValidEmail_NullInput(string email, bool expectedResult)
    {
        // Arrange

        // Act
        bool actualResult = Email.IsValidEmail(email);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    } 
}
