using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class StringLengthCalculatorTests
{
    [Test]
    public void Test_Calculate_EmptyString_ReturnsZero()
    {
        // Arrange
        string input = string.Empty;

        // Act
        int actualResult = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_Calculate_SingleEvenLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "test";

        // Act
        int actualResult = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(896));

    }

    [Test]
    public void Test_Calculate_SingleOddLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "SoftUni";

        // Act
        int actualResult = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(356));
    }

    [Test]
    public void Test_Calculate_WholeSentenceString_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "SoftUni is the best!";

        // Act
        int actualResult = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(3624));
    }

}

