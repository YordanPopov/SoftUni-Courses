using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class DeliverySystemTests
{
    DeliverySystem _deliverySystem;

    [SetUp]
    public void SetUp()
    {
        this._deliverySystem = new DeliverySystem();
    }

    [Test]
    public void Test_Constructor_CheckInitialEmptyDeliveryCollectionAndCount()
    {
        var result = _deliverySystem.GetAllDeliveriesInProgress();

        Assert.That(result, Has.Count.EqualTo(0));
        Assert.IsEmpty(result);
        Assert.IsNotNull(result);
        Assert.That(_deliverySystem.DeliveriesInProgressCount, Is.EqualTo(0));
    }

    [Test]
    public void Test_AddDelivery_ValidItem_AddNewItemForDelivery()
    {
        string item = "test item";

        var expectedResult = new List<string> { "test item" };

        _deliverySystem.AddDelivery(item);
        var actualResult = _deliverySystem.GetAllDeliveriesInProgress();

        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.GreaterThan(0));
        Assert.That(actualResult[0], Is.EqualTo(item));

    }

    [Test]
    public void Test_AddDelivery_NullOrEmptyItem_ThrowsArgumentException()
    {
        string nullInput = null;

        Assert.That(() => _deliverySystem.AddDelivery(nullInput), Throws.ArgumentException.With.Message.EqualTo("Item info cannot be empty or whitespace."));
        Assert.That(() => _deliverySystem.AddDelivery(string.Empty), Throws.ArgumentException.With.Message.EqualTo("Item info cannot be empty or whitespace."));
        Assert.That(() => _deliverySystem.AddDelivery("  "), Throws.ArgumentException.With.Message.EqualTo("Item info cannot be empty or whitespace."));
    }

    [Test]
    public void Test_FinishDelivery_ValidItem_RemoveExistingItemAsDelivered()
    {
        var expectedResult = new List<string> { "test item2", "test item3" };

        _deliverySystem.AddDelivery("test item");
        _deliverySystem.AddDelivery("test item2");
        _deliverySystem.AddDelivery("test item3");
        _deliverySystem.FinishDelivery("test item");
        var actualResult = _deliverySystem.GetAllDeliveriesInProgress();

        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.GreaterThan(0));
        Assert.That(actualResult[0], Is.EqualTo("test item2"));
    }

    [Test]
    public void Test_FinishDelivery_NullOrEmptyOrNonExistingItem_ThrowsArgumentException()
    {
        string nullInput = null;

        Assert.That(() => _deliverySystem.FinishDelivery(nullInput), Throws.ArgumentException.With.Message.EqualTo("Item not found in the system."));
        Assert.That(() => _deliverySystem.FinishDelivery("    "), Throws.ArgumentException.With.Message.EqualTo("Item not found in the system."));
        Assert.That(() => _deliverySystem.FinishDelivery(string.Empty), Throws.ArgumentException.With.Message.EqualTo("Item not found in the system."));
    }

    [Test]
    public void Test_GetAllDeliveriesInProgress_AddAndFinishDeliveries_ReturnExpectedDeliveryCollection()
    {
        var expectedResult = new List<string> { "test item2", "test item3" };

        _deliverySystem.AddDelivery("test item");
        _deliverySystem.AddDelivery("test item2");
        _deliverySystem.AddDelivery("test item3");
        _deliverySystem.FinishDelivery("test item");
        var actualResult = _deliverySystem.GetAllDeliveriesInProgress();

        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.GreaterThan(0));
        Assert.That(actualResult[0], Is.EqualTo("test item2"));
    }
}

