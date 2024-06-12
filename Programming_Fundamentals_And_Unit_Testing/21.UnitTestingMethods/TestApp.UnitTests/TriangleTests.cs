using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class TriangleTests
{
    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size0()
    {
        // Arrange
        int input = 0;

        // Act
        string actualResult = Triangle.PrintTriangle(input);
        string expectedResult = string.Empty;

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size3()
    {
        // Arrange
        int input = 3;

        // Act
        string actualResult = Triangle.PrintTriangle(input);
        string expectedResult = "1" + Environment.NewLine
            + "1 2" + Environment.NewLine
            + "1 2 3" + Environment.NewLine
            + "1 2" + Environment.NewLine
            + "1";

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size5()
    {
        // Arrange
        int input = 5;

        // Act
        string actualResult = Triangle.PrintTriangle(input);
        string expectedResult = "1" + Environment.NewLine
            + "1 2" + Environment.NewLine
            + "1 2 3" + Environment.NewLine
            + "1 2 3 4" + Environment.NewLine
            + "1 2 3 4 5" + Environment.NewLine
            + "1 2 3 4" + Environment.NewLine
            + "1 2 3" + Environment.NewLine
            + "1 2" + Environment.NewLine
            + "1";

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}
