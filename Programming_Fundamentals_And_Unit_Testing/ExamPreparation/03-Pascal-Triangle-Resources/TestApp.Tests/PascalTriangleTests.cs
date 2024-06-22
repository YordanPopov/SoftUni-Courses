using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class PascalTriangleTests
{
    [TestCase(0, "")]
    [TestCase(1, "1 \n")]
    [TestCase(2, "1 \n1 1 \n")]
    [TestCase(6, "1 \n1 1 \n1 2 1 \n1 3 3 1 \n1 4 6 4 1 \n1 5 10 10 5 1 \n")]
    [TestCase(4, "1 \n1 1 \n1 2 1 \n1 3 3 1 \n")]
    public void Test_PrintTriangle_ShouldReturnCorrectString(int n, string expectedResult)
    {
        // Act
        string actualResult = PascalTriangle.PrintTriangle(n);

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }
}
