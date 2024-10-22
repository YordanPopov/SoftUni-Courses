using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class FibonacciTests
{

    [Test]
    public void Test_FibonacciInRange_StartNumberGreaterThanEndNumber_ReturnsErrorMessage()
    {
        string result = Fibonacci.FibonacciInRange(10, 1);

        Assert.That(result, Is.EqualTo("Start number should be less than end number."));
    }

    [Test]
    public void Test_FibonacciInRange_StartAndEndNumberEqualToZero_ReturnsZero()
    {
        string result = Fibonacci.FibonacciInRange(0, 0);

        Assert.That(result, Is.EqualTo("0"));
    }

    [Test]
    public void Test_FibonacciInRange_StartAndEndNumberEqualToOne_ReturnsTwoTimesOne()
    {
        string result = Fibonacci.FibonacciInRange(1, 1);

        Assert.That(result, Is.EqualTo("1 1"));
    }

    [Test]
    public void Test_FibonacciInRange_NoFibonacciNumberBetweenStartAndEndNumbers_ReturnsEmptyString()
    {
        string result = Fibonacci.FibonacciInRange(9, 12);

        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_FibonacciInRange_ValidRange_ReturnsFibonacciSequence()
    {
        string result = Fibonacci.FibonacciInRange(2, 90);

        Assert.That(result, Is.EqualTo("2 3 5 8 13 21 34 55 89"));
    }
}

