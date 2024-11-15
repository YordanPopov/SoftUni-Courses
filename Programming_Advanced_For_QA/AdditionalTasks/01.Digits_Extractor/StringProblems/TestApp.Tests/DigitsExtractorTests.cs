using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class DigitsExtractorTests
{
    [Test]
    public void Test_FindDigits_EmptyStringInput_ReturnsNoDigitsMessage()
    {
        string input = string.Empty;

        string result = DigitsExtractor.FindDigits(input);

        Assert.That(result, Is.EqualTo("No digits!"));
    }

    [Test]
    public void Test_FindDigits_NoDIgitsInput_ReturnsNoDigitsMessage()
    {
        string input = "SoftUni is the best!";

        string result = DigitsExtractor.FindDigits(input);

        Assert.That(result, Is.EqualTo("No digits!"));
    }

    [Test]
    public void Test_FindDigits_OnlyDigitsStringInpput_ReturnsSameDigitsString()
    {
        string input = "456";

        string result = DigitsExtractor.FindDigits(input);

        Assert.That(result, Is.EqualTo("456"));
    }

    [Test]
    public void Test_FindDigits_DigitsAndLetters_ReturnsOnlyDigits()
    {
        string input = "SoftUni1 is2 the3 best4!";

        string result = DigitsExtractor.FindDigits(input);

        Assert.That(result, Is.EqualTo("1234"));
    }
}

