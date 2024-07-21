using NUnit.Framework;

using System;

using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles _vehicles;

    [SetUp]
    public void SetUp()
    {
        this._vehicles = new();
    }
    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
        string[] input =  
            { 
                "Car/Ford/Focus/120",
                "Truck/Volvo/VNL/500",
                "Car/Toyota/Camry/150",
            };
        string expectedResult = $"Cars:{Environment.NewLine}Ford: Focus - 120hp{Environment.NewLine}Toyota: Camry - 150hp{Environment.NewLine}Trucks:{Environment.NewLine}Volvo: VNL - 500kg";

        // Act
        string actualResult = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        // Arrange
        string[] emptyInput = Array.Empty<string>();
        string expectedResult = $"Cars:{Environment.NewLine}Trucks:";

        // Act
        string actualResult = this._vehicles.AddAndGetCatalogue(emptyInput);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
