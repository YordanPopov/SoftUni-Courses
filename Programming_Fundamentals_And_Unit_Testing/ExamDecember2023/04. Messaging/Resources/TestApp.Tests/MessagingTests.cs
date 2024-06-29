using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.Tests;

public class MessagingTests
{
    [Test]
    public void Test_GetMessage_WithValidInput_ReturnsExpectedMessage()
    {
        // Arrange
        List<int> numbers = new List<int> { 10, 11, 12, 13, 37};
        string s = "Messaging";
        string expectedResult = "esgnM";

        // Act
        string actualResult = Messaging.GetMessage(numbers, s);


        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));        
    }

    [Test]
    public void Test_GetMessage_EmptyList_ReturnsEmptyString()
    {
        // Arrange
        List<int> emptyList = new List<int>();
        string s = "Test";

        // Act
        string actualResult = Messaging.GetMessage(emptyList, s);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_GetMessage_EmptyString_ReturnsEmptyString()
    {
        List<int> numbers = new List<int> { 11, 12, 13, 14, 15 };
        string s = string.Empty;

        // Act
        string actualResult = Messaging.GetMessage(numbers, s);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_GetMessage_NullList_ReturnsEmptyString()
    {
        List<int>? nullList = null;
        string s = "Test";

        // Act
        string actualResult = Messaging.GetMessage(nullList, s);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_GetMessage_NullString_ReturnsEmptyString()
    {
        List<int> numbers = new List<int> { 11, 12, 13, 14, 15 };
        string? s = null;

        // Act
        string actualResult = Messaging.GetMessage(numbers, s);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }
}
