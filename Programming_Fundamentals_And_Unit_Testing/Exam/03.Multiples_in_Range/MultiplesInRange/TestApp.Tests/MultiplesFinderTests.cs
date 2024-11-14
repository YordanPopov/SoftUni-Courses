using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class MultiplesFinderTests
{
    [Test]
    public void Test_FindMultiples_StartGreaterThanEndNumber_ReturnsErrorMessage()
    {
        string expectedMsg = "Start number should not be greater than end number.";

        string result = MultiplesFinder.FindMultiples(20, 10, 5);

        Assert.That(result, Is.EqualTo(expectedMsg));
    }

    [Test]
    public void Test_FindMultiples_NoMultiplesOfTheDevisor_ReturnsEmptyString()
    {
        string expectedMsg = string.Empty;

        string result = MultiplesFinder.FindMultiples(1, 3, 7);

        Assert.That(result, Is.EqualTo(expectedMsg));
    }

    [Test]
    public void Test_FindMultiples_SingleMultipleOfTheDevisor_ReturnsSingleNumber()
    {
        string expectedMsg = "3";

        string result = MultiplesFinder.FindMultiples(3, 4, 3);

        Assert.That(result, Is.EqualTo(expectedMsg));
    }

    [Test]
    public void Test_FindMultiples_ManyMultiplesOfTheDevisor_ReturnsCorrectNumbersInRange()
    {
        string expectedMsg = "6 9 12 15";

        string result = MultiplesFinder.FindMultiples(5, 15, 3);

        Assert.That(result, Is.EqualTo(expectedMsg));
    }

    [Test]
    public void Test_FindMultiples_ZeroInRange_ReturnsZero()
    {
        string expectedMsg = "0";

        string result = MultiplesFinder.FindMultiples(0, 0, 1);

        Assert.That(result, Is.EqualTo(expectedMsg));
    }
}