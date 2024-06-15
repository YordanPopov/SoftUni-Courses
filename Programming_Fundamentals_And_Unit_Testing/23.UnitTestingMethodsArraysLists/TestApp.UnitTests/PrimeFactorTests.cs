using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        // Arrange
        long primeNumber = 23;

        // Act
        long actualResult = PrimeFactor.FindLargestPrimeFactor(primeNumber);

        // Assert
        Assert.That(actualResult, Is.EqualTo(23));
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        long primeNumber = 230;

        // Act
        long actualResult = PrimeFactor.FindLargestPrimeFactor(primeNumber);

        // Assert
        Assert.That(actualResult, Is.EqualTo(23));
    }
}
