using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class ParkingSystemTests
{
    ParkingSystem _parking;

    [SetUp]
    public void SetUp()
    {
        this._parking = new ParkingSystem();
    }

    [Test]
    public void Test_Contructor_CheckInitialEmptyCarCollectionAndCount()
    {
        List<string> actualResult = _parking.GetAllParkedCars();

        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
        Assert.IsNotNull(actualResult);
        Assert.That(_parking.CarCount, Is.EqualTo(0));
    }

    [Test]
    public void Test_ParkCar_ValidCarNumber_AddNewCar()
    {
        string carNumber = "XX1111ZZ";
        List<string> expectedResult = new List<string>() { "XX1111ZZ" };

        _parking.ParkCar(carNumber);
        List<string> actualResult = _parking.GetAllParkedCars();

        CollectionAssert.AreEqual(actualResult, expectedResult);
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult[0], Is.EqualTo(carNumber));    
    }

    [Test]
    public void Test_ParkCar_NullOrEmptyCarNumber_ThrowsArgumentException()
    {
        string nullCarNumber = null;
        string whiteSpacesCarNumber = "   ";

        Assert.That(() => _parking.ParkCar(nullCarNumber), Throws.ArgumentException.With.Message.EqualTo("Car number cannot be empty or whitespace."));
        Assert.That(() => _parking.ParkCar(whiteSpacesCarNumber), Throws.ArgumentException.With.Message.EqualTo("Car number cannot be empty or whitespace."));
        Assert.That(() => _parking.ParkCar(string.Empty), Throws.ArgumentException.With.Message.EqualTo("Car number cannot be empty or whitespace."));
    }

    [Test]
    public void Test_RemoveCar_ValidCarNumber_RemoveFirstCar()
    {
        List<string> expectedResult = new List<string>() { "XX1111ZZ" };

        _parking.ParkCar("XX1111ZZ");
        _parking.ParkCar("XX1111XX");
        _parking.RemoveCar("XX1111XX");
        List<string> actualResult = _parking.GetAllParkedCars();

        CollectionAssert.AreEqual(actualResult, expectedResult);
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult[0], Is.EqualTo("XX1111ZZ"));
    }

    [Test]
    public void Test_RemoveCar_NullOrEmptyCarNumber_ThrowsArgumentException()
    {
        string nullCarNumber = null;
        string whiteSpacesCarNumber = "   ";

        Assert.That(() => _parking.RemoveCar(nullCarNumber), Throws.ArgumentException.With.Message.EqualTo("Car not found in the system."));
        Assert.That(() => _parking.RemoveCar(whiteSpacesCarNumber), Throws.ArgumentException.With.Message.EqualTo("Car not found in the system."));
    }

    [Test]
    public void Test_GetAllParkedCars_AddAndRemoveCar_ReturnsExpectedCarsCollection()
    {
        List<string> expectedResult = new List<string>() { "XX1111ZZ" };

        _parking.ParkCar("XX1111ZZ");
        _parking.ParkCar("XX1111XX");
        _parking.RemoveCar("XX1111XX");
        List<string> actualResult = _parking.GetAllParkedCars();

        CollectionAssert.AreEqual(actualResult, expectedResult);
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult[0], Is.EqualTo("XX1111ZZ"));
    }
}
