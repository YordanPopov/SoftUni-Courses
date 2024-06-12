using NUnit.Framework;

namespace TestApp.UnitTests;

public class CalculateTests
{
    [TestCase(5, 5, 10)]
    [TestCase(-5, -5, -10)]
    [TestCase(-5, 5, 0)]
    public void Test_Addition(int a, int b, int expected)
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actualResult = calculator.Addition(a, b);

        // Assert
        Assert.AreEqual(expected, actualResult, "Addition did not work properly.");
    }

    [TestCase(10, 5, 5)]
    [TestCase(5, 5, 0)]
    [TestCase(0, 5, -5)]
    [TestCase(-5, -5, 0)]
    [TestCase(-5, -10, 5)]
    public void Test_Subtraction(int a, int b, int expected)
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actualResult = calculator.Subtraction(a, b);

        // Assert
        Assert.AreEqual(expected, actualResult, "Subtraction did not work properly.");
    }
}
