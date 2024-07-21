using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop _shop;

    [SetUp]
    public void SetUp()
    {
        this._shop = new Shop();
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        string[] products = new string[] { "1234 CocaCola 3 1.70", "5678 Ariana 5 1.50" };
        string expected = $"5678{Environment.NewLine}-- Ariana - $1.50: 5{Environment.NewLine}-- $7.50"
                          + Environment.NewLine +
                          $"1234{Environment.NewLine}-- CocaCola - $1.70: 3{Environment.NewLine}-- $5.10";

        // Act
        string actualResult = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        // Arange
        string[] products = Array.Empty<string>();

        // Act
        string actualResult = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }
}
