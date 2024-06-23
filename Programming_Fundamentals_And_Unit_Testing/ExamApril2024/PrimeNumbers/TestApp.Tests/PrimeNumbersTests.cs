using System;
using NUnit.Framework;

namespace TestApp.Tests;
public class PrimeNumbersTests
{
    [Test]
    public void Test_GetPrimeNumbersInRange_StartNumberBiggerThanEndNumber_ReturnsErrorMessage()
    {
        // Arrange
        int startNumber = 10;
        int endNumber = 1;
        string expectedResult = "Start number should be bigger than end number.";

        // Act
        string actualResult = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_StartAndEndNumberAreEqual_ReturnsEmptyString()
    {
        // Arrange
        int startNumber = 1;
        int endNumber = 1;
        string expectedResult = "";

        // Act
        string actualResult = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_NoPrimeNumbers_ReturnsEmptyString()
    {
        // Arrange
        int startNumber = 0;
        int endNumber = 1;
        string expectedResult = "";

        // Act
        string actualResult = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_WithPrimeAndNonPrimeNumbers_ReturnsOnlyPrimeNumbers()
    {
        // Arrange
        int startNumber = 1;
        int endNumber = 18;
        string expectedResult = "2 3 5 7 11 13 17";

        // Act
        string actualResult = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_OnlyPrimeNumbers_ReturnsAllNumbers()
    {
        // Arrange
        int startNumber = 3;
        int endNumber = 5;
        string expectedResult = "3 5";

        // Act
        string actualResult = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

