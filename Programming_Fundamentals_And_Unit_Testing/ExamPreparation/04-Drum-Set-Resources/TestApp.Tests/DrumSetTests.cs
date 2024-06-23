using NUnit.Framework;
using System;

using System.Collections.Generic;

namespace TestApp.Tests;

public class DrumSetTests
{
    [Test]
    public void Test_Drum_TerminateCommandNotGiven_ThrowsArgumentException()
    {
        // Arrange
        decimal money = 100;
        List<int> initialQuality = new List<int> { 2, 3 };
        List<string> commands = new List<string> { "1", "1" };

        // Acct & Assert
        Assert.That(() => DrumSet.Drum(money, initialQuality, commands), Throws.ArgumentException);
    }

    [Test]
    public void Test_Drum_StringGivenAsCommand_ThrowsArgumentException()
    {
        // Arrange
        decimal money = 100;
        List<int> initialQuality = new List<int> { 2, 3 };
        List<string> commands = new List<string>{ "1", "string", "Hit it again, Gabsy!" };

        // Acct & Assert
        Assert.That(() => DrumSet.Drum(money, initialQuality, commands), Throws.ArgumentException);
    }

    [Test]
    public void Test_Drum_ReturnsCorrectQualityAndAmount()
    {
        // Arrange
        decimal money = 100;
        List<int> initialQuality = new List<int> { 3, 4 };
        List<string> commands = new List<string> { "1", "1", "Hit it again, Gabsy!" };
        string expectedResult = "1 2\nGabsy has 100.00lv.";

        // Act
        string actualResult = DrumSet.Drum(money, initialQuality, commands);


        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_Drum_BalanceZero_WithOneDrumLeftOver_ReturnsCorrectQualityAndAmount()
    {
        // Arrange
        decimal money = 0;
        List<int> initialQuality = new List<int> { 3, 4, 5 };
        List<string> commands = new List<string> { "2", "2", "Hit it again, Gabsy!" };
        string expectedResult = "1\nGabsy has 0.00lv.";

        // Act
        string actualResult = DrumSet.Drum(money, initialQuality, commands);


        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Drum_NotEnoughBalance_RemovesAllDrums_ReturnsCorrectQualityAndAmount()
    {
        // Arrange
        decimal money = 5;
        List<int> initialQuality = new List<int> {3, 4 ,5};
        List<string> commands = new List<string> { "3", "3", "Hit it again, Gabsy!" };
        string expectedResult = "\nGabsy has 5.00lv.";

        // Act
        string actualResult = DrumSet.Drum(money, initialQuality, commands);


        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
    [Test]
    public void Test_Drum_ReturnsCorrectQualityAndAmount2()
    {
        // Arrange
        decimal money = 100;
        List<int> initialQuality = new List<int> { 3, 4 };
        List<string> commands = new List<string> { "3", "1", "Hit it again, Gabsy!" };
        string expectedResult = "2 4\nGabsy has 79.00lv.";

        // Act
        string actualResult = DrumSet.Drum(money, initialQuality, commands);


        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));

    }
}
