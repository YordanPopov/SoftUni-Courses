using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using NuGet.Frameworks;

namespace TestApp.Tests;

[TestFixture]
public class CargoManagementSystemTests
{
    CargoManagementSystem _cargo;

    [SetUp]
    public void SetUp()
    {
        this._cargo = new CargoManagementSystem();
    }

    [Test]
    public void Test_Constructor_CheckInitialEmptyCargoCollectionAndCount()
    {
        // Act
        List<string> actualResult = this._cargo.GetAllCargos();

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
        Assert.IsNotNull(actualResult);
        Assert.That(this._cargo.CargoCount, Is.EqualTo(0));

    }

    [Test]
    public void Test_AddCargo_ValidCargoName_AddNewCargo()
    {
        // Arrange
        string cargoName = "test";

        this._cargo.AddCargo(cargoName);

        List<string> expectedResult = new List<string>()
        {
            "test"
        };


        // Act
        List<string> actualResult = this._cargo.GetAllCargos();

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult[0], Is.EqualTo("test"));
    }

    [Test]
    public void Test_AddCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Assert
        string nullCargoName = null;
        string emptyCargoName = string.Empty;
        string whiteSpacesCargoName = "  ";


        // Act && Assert
        Assert.That(() => this._cargo.AddCargo(nullCargoName), Throws.ArgumentException.With.Message.EqualTo("Cargo cannot be empty or whitespace."));
        Assert.That(() => this._cargo.AddCargo(emptyCargoName), Throws.ArgumentException.With.Message.EqualTo("Cargo cannot be empty or whitespace."));
        Assert.That(() => this._cargo.AddCargo(whiteSpacesCargoName), Throws.ArgumentException.With.Message.EqualTo("Cargo cannot be empty or whitespace."));
    }

    [Test]
    public void Test_RemoveCargo_ValidCargoName_RemoveFirstCargoName()
    {
        // Arrange
        this._cargo.AddCargo("test1");
        this._cargo.AddCargo("test2");
        this._cargo.AddCargo("test3");
        this._cargo.AddCargo("test4");

        List<string> expectedResult = new List<string>()
        {
            "test2",
            "test3",
            "test4"
        };

        // Act
        this._cargo.RemoveCargo("test1");

        List<string> actualResult = this._cargo.GetAllCargos();

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(3));
    }

    [Test]
    public void Test_RemoveCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        string nullCargoName = null;
        string emptyCargoName = string.Empty;

        // Act && Assert
        Assert.That(() => this._cargo.RemoveCargo(nullCargoName), Throws.ArgumentException.With.Message.EqualTo("Cargo not found in the system."));
        Assert.That(() => this._cargo.RemoveCargo(emptyCargoName), Throws.ArgumentException.With.Message.EqualTo("Cargo not found in the system."));
    }

    [Test]
    public void Test_GetAllCargos_AddedAndRemovedCargos_ReturnsExpectedCargoCollection()
    {
        // Arrange
        this._cargo.AddCargo("test1");
        this._cargo.AddCargo("test2");
        this._cargo.AddCargo("test3");
        this._cargo.AddCargo("test4");
        this._cargo.AddCargo("test5");
        this._cargo.AddCargo("test6");

        List<string> expectedResult = new List<string>()
        {
            "test2",
            "test3",
            "test4"
        };

        // Act
        this._cargo.RemoveCargo("test1");
        this._cargo.RemoveCargo("test5");
        this._cargo.RemoveCargo("test6");

        List<string> actualResult = this._cargo.GetAllCargos();

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(3));
    }
}

    