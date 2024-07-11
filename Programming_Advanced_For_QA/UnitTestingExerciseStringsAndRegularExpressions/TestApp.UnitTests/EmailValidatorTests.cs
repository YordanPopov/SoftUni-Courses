using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    [TestCase("test@test.test")]
    [TestCase(".t_e%s+t-@te.-st.test")]
    [TestCase("test2@test2.te")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Act
        bool actualResult = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(actualResult, Is.True);
    }

    [TestCase("      ")]
    [TestCase("test@test.t")]
    [TestCase("test_test,test")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Act
        bool actualResult = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(actualResult, Is.False);
    }
}
