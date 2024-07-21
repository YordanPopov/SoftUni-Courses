using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PlanetTests
{
    [Test]
    public void Test_CalculateGravity_ReturnsCorrectCalculation()
    {
        // Arrange
        Planet earth = new("Earth", 12742, 149600000, 1);
        double mass = 1000;
        double expectedGravity = mass * 6.67430e-11 / Math.Pow(earth.Diameter / 2, 2);

        // Act
        double actualResult = earth.CalculateGravity(mass);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedGravity));
    }

    [Test]
    public void Test_GetPlanetInfo_ReturnsCorrectInfo()
    {
        // Arrange
        Planet marc = new("Marc", 6754.8, 142000000, 2);
        string expectedResult = "Planet: Marc" + Environment.NewLine +
                                "Diameter: 6754.8 km" + Environment.NewLine +
                                "Distance from the Sun: 142000000 km" + Environment.NewLine +
                                "Number of Moons: 2";

        // Act
        string actualResult = marc.GetPlanetInfo();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
