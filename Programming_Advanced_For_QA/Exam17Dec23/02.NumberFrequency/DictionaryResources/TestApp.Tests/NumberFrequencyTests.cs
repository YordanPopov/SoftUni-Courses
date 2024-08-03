using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class NumberFrequencyTests
{
    [Test]
    public void Test_CountDigits_ZeroNumber_ReturnsEmptyDictionary()
    {
        // Arrange
        int number = 0;

        // Act
        Dictionary<int, int> actualResult = NumberFrequency.CountDigits(number);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_CountDigits_SingleDigitNumber_ReturnsDictionaryWithSingleEntry()
    {
        // Arrange
        int number = 6;

        Dictionary<int, int> expectedResult = new()
        {
            [6] = 1
        };

        // Act
        Dictionary<int, int> actualResult = NumberFrequency.CountDigits(number);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_CountDigits_MultipleDigitNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        int number = 123211;

        Dictionary<int, int> expectedResult = new()
        {
            [1] = 3,
            [2] = 2,
            [3] = 1,
        };

        // Act
        Dictionary<int, int> actualResult = NumberFrequency.CountDigits(number);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_CountDigits_NegativeNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        int number = -123211;

        Dictionary<int, int> expectedResult = new()
        {
            [1] = 3,
            [2] = 2,
            [3] = 1,
        };

        // Act
        Dictionary<int, int> actualResult = NumberFrequency.CountDigits(number);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}
