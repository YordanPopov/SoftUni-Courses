using NUnit.Framework;

namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        // Arrange 
        int number = 0;

        // Act
        int actualResult = Fibonacci.CalculateFibonacci(number);

        // Assert
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_CalculateFibonacci_PositiveInput()
    {
        // Arrange 
        int number = 9;

        // Act
        int actualResult = Fibonacci.CalculateFibonacci(number);

        // Assert
        Assert.That(actualResult, Is.EqualTo(34));
    }
}