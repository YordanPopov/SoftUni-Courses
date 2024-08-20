using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class LetterCountCalculatorTests
{
    [Test]
    public void Test_Calculate_EmptyString_ReturnsZero()
    {
        // Arrange
        string input = string.Empty;

        // Act
        int actualResult = LetterCountCalculator.Calculate(input);

        // Assert.
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_Calculate_NoUpperCase_ReturnsZero()
    {
        // Arrange
        string input = "test";

        // Act
        int actualResult = LetterCountCalculator.Calculate(input);

        // Assert.
        Assert.That(actualResult, Is.EqualTo(0));

    }

    [Test]
    public void Test_Calculate_NoLowerCase_ReturnsZero()
    {
        // Arrange
        string input = "TEST";

        // Act
        int actualResult = LetterCountCalculator.Calculate(input);

        // Assert.
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_Calculate_UpperAndLowerCase_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "TesT tESt";

        // Act
        int actualResult = LetterCountCalculator.Calculate(input);

        // Assert.
        Assert.That(actualResult, Is.EqualTo(16));
    }
}

