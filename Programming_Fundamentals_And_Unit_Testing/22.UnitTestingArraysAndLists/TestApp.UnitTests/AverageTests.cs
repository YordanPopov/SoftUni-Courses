using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class AverageTests
{
    [Test]
    public void Test_CalculateAverage_InputHasOneElement_ShouldReturnSameElement()
    {
        // Arrange
        int[] oneElementArr = { 20 };

        // Act
        double actualResult = Average.CalculateAverage(oneElementArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(20));
    }

    [Test]
    public void Test_CalculateAverage_InputHasPositiveIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] positiveNumbersArr = new int[] { 1, 2, 3, 4, 5 };

        // Act
        double actualResult = Average.CalculateAverage(positiveNumbersArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(3));
    }

    [Test]
    public void Test_CalculateAverage_InputHasNegativeIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] negativeNumbersArr = new int[] { -1, -2, -3, -4, -5 };

        // Act
        double actualResult = Average.CalculateAverage(negativeNumbersArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(-3));
    }

    [Test]
    public void Test_CalculateAverage_InputHasMixedIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] mixedNumbersArr = new int[] { 2, 8, -10, 1, 9};

        // Act
        double actualResult = Average.CalculateAverage(mixedNumbersArr);

        // Assert
        Assert.That(actualResult, Is.EqualTo(2));
    }
}
