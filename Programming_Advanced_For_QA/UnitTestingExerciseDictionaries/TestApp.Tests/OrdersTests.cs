using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string actualResult = Orders.Order(input);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = {"banana 1.52 100", "orange 2.34 50", "apple 0.52 25", "apple 0.52 40" };
        string expectedResult = "banana -> 152.00" + Environment.NewLine +
                                "orange -> 117.00" + Environment.NewLine +
                                "apple -> 33.80";

        // Act
        string actualResult = Orders.Order(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
        //Assert.That(result, Is.EqualTo($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98"));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = { "banana 2 100", "orange 2 50", "apple 1 25", "apple 1 40" };
        string expectedResult = "banana -> 200.00" + Environment.NewLine +
                                "orange -> 100.00" + Environment.NewLine +
                                "apple -> 65.00";

        // Act
        string actualResult = Orders.Order(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        string[] input = { "banana 2 100.25", "orange 2 50.34", "apple 1 25.31", "apple 1 40.06" };
        string expectedResult = "banana -> 200.50" + Environment.NewLine +
                                "orange -> 100.68" + Environment.NewLine +
                                "apple -> 65.37";

        // Act
        string actualResult = Orders.Order(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
