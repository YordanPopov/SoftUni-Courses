using NUnit.Framework;

namespace TestApp.UnitTests;

public class FactorialTests
{
    [Test]
    public void Test_CalculateFactorial_InputZero_ReturnsOne()
    {
        // Arrange
        int number = 0;

        // Act
        int actualResult = Factorial.CalculateFactorial(number);
        int expectedResult = 1;

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [TestCase(5, 120)]
    [TestCase(6, 720)]
    [TestCase(7, 5040)]
    public void Test_CalculateFactorial_InputPositiveNumber_ReturnsCorrectFactorial(int number, int expectedResult)
    {
        // Arrange

        // Act
        int actualResult = Factorial.CalculateFactorial(number);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}
