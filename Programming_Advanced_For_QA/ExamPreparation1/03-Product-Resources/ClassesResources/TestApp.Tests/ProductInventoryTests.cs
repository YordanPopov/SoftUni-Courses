using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        this._inventory.AddProduct("Banana", 2.0, 5);

        string expectedResult = "Product Inventory:" + Environment.NewLine +
                                "Banana - Price: $2.00 - Quantity: 5";

        // Act
        string actualResult = this._inventory.DisplayInventory();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        string expectedResult = "Product Inventory:";

        // Act
        string actualResult = this._inventory.DisplayInventory();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        this._inventory.AddProduct("Banana", 2.0, 5);
        this._inventory.AddProduct("Orange", 5.0, 2);
        this._inventory.AddProduct("Apple", 1.5, 7);

        string expectedResult = "Product Inventory:" + Environment.NewLine +
                                "Banana - Price: $2.00 - Quantity: 5" + Environment.NewLine +
                                "Orange - Price: $5.00 - Quantity: 2" + Environment.NewLine +
                                "Apple - Price: $1.50 - Quantity: 7";

        // Act
        string actualResult = this._inventory.DisplayInventory();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Act
        double actualResult = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        this._inventory.AddProduct("Banana", 2.0, 5);
        this._inventory.AddProduct("Orange", 5.0, 2);
        this._inventory.AddProduct("Apple", 1.5, 5);

        // Act
        double actualResult = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(actualResult, Is.EqualTo(27.5));
    }
}
