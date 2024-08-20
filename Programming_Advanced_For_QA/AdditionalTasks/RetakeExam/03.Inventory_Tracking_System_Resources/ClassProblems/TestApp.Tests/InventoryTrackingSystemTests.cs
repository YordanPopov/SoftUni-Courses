using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class InventoryTrackingSystemTests
{
    private InventoryTrackingSystem _inventory;
    private readonly List<string> _tems = new()
    {
        "Item1",
        "Item2",
        "Item3",
        "Item4"
    };

    string nullItemName = null;
    string emptyItemName = string.Empty;
    string whiteSpacesItemName = "  ";

    [SetUp]
    public void SetUp()
    {
        this._inventory = new InventoryTrackingSystem();
    }

    [Test]
    public void Test_Constructor_CheckInitialEmptyItemCollectionAndCount()
    {
        // Act 
        List<string> actualResult = this._inventory.GetAllItems();

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(this._inventory.ItemCount, Is.EqualTo(0));
    }

    [Test]
    public void Test_AddItem_ValidItemName_AddNewItem()
    {
        // Arrange
        foreach (var item in _tems)
        {
            this._inventory.AddItem(item);
        }

        // Act
        List<string> actualResult = this._inventory.GetAllItems();

        // Assert
        CollectionAssert.AreEqual(_tems, actualResult);
    }

    [Test]
    public void Test_AddItem_NullOrEmptyItemName_ThrowsArgumentException()
    {
        // Act && Assert
        Assert.That(() => this._inventory.AddItem(nullItemName), Throws.ArgumentException.With.Message.EqualTo("Items cannot be empty or whitespace."));
        Assert.That(() => this._inventory.AddItem(emptyItemName), Throws.ArgumentException.With.Message.EqualTo("Items cannot be empty or whitespace."));
        Assert.That(() => this._inventory.AddItem(whiteSpacesItemName), Throws.ArgumentException.With.Message.EqualTo("Items cannot be empty or whitespace."));
    }

    [Test]
    public void Test_RemoveItem_ValidItemName_RemoveFirstItemName()
    {
        // Arrange
        foreach (var item in _tems)
        {
            this._inventory.AddItem(item);
        }

        List<string> expectedResult = _tems.Skip(1).ToList();

        // Act
        this._inventory.RemoveItem("Item1");
        List<string> actualResult = this._inventory.GetAllItems();

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_RemoveItem_NullOrEmptyItemName_ThrowsArgumentException()
    {
        // Arrange
        foreach (var item in _tems)
        {
            this._inventory.AddItem(item);
        }

        // Act && Assert
        Assert.That(() => this._inventory.RemoveItem(nullItemName), Throws.ArgumentException.With.Message.EqualTo("Items not found in the system."));
        Assert.That(() => this._inventory.RemoveItem(emptyItemName), Throws.ArgumentException.With.Message.EqualTo("Items not found in the system."));
        Assert.That(() => this._inventory.RemoveItem(whiteSpacesItemName), Throws.ArgumentException.With.Message.EqualTo("Items not found in the system."));
        Assert.That(() => this._inventory.RemoveItem("Item"), Throws.ArgumentException.With.Message.EqualTo("Items not found in the system."));
    }

    [Test]
    public void Test_GetAllItems_AddedAndRemovedItems_ReturnsExpectedItemCollection()
    {
        // Arrange
        foreach (var item in _tems)
        {
            this._inventory.AddItem(item);
        }

        List<string> expectedResult = _tems.Skip(2).ToList();

        // Act
        this._inventory.RemoveItem("Item1");
        this._inventory.RemoveItem("Item2");
        List<string> actualResult = this._inventory.GetAllItems();

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}
