using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        this._chatRoom.SendMessage("Tester", "Hello!");

        // Act
        string actualResult = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(actualResult, Does.Contain("Chat Room Messages:"));
        Assert.That(actualResult, Does.Contain("Tester: Hello! - Sent at "));
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Act
        string actualResult = this._chatRoom.DisplayChat();

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        this._chatRoom.SendMessage("Tester", "Hello!");
        this._chatRoom.SendMessage("Tester2", "Hi!");

        // Act
        string actualResult = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(actualResult, Does.Contain("Chat Room Messages:"));
        Assert.That(actualResult, Does.Contain("Tester: Hello! - Sent at "));
        Assert.That(actualResult, Does.Contain("Tester2: Hi! - Sent at "));
    }
}
