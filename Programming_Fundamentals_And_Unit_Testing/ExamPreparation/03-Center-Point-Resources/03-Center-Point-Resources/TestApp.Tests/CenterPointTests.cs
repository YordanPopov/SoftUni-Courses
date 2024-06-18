using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class CenterPointTests
{
    [Test]
    public void Test_GetClosest_WhenFirstPointIsCloser_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 1d;
        double y1 = 1d;
        double x2 = 2d;
        double y2 = 2d;
        string expectedResult = "(1, 1)";

        // Act
        string actualResult = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsCloser_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 2d;
        double y1 = 2d;
        double x2 = 1d;
        double y2 = 1d;
        string expectedResult = "(1, 1)";

        // Act
        string actualResult = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_GetClosest_WhenBothPointsHaveEqualDistance_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 2d;
        double y1 = 2d;
        double x2 = 2d;
        double y2 = 2d;
        string expectedResult = "(2, 2)";

        // Act
        string actualResult = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_GetClosest_WhenFirstPointIsNegative_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = -1d;
        double y1 = -1d;
        double x2 = 2d;
        double y2 = 2d;
        string expectedResult = "(-1, -1)";

        // Act
        string actualResult = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsNegative_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 2d;
        double y1 = 2d;
        double x2 = -2d;
        double y2 = -2d;
        string expectedResult = "(-2, -2)";

        // Act
        string actualResult = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}
