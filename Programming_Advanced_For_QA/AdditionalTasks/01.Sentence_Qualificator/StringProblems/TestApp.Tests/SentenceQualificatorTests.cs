using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class SentenceQualificatorTests
{
    [Test]
    public void Test_QualifySentence_EmptyString_ReturnsCorrectMessage()
    {
        string input = string.Empty;

        string result = SentenceQualificator.QualifySentence(input);

        Assert.That(result, Is.EqualTo("neutral"));
    }

    [Test]
    public void Test_QualifySentence_WhitespacesString_ReturnsCorrectMessage()
    {
        string input = "   ";

        string result = SentenceQualificator.QualifySentence(input);

        Assert.That(result, Is.EqualTo("neutral"));
    }

    [Test]
    public void Test_QualifySentence_EvenAsciiString_ReturnsCorrectMessage()
    {
        string input = "SoftUni";

        string result = SentenceQualificator.QualifySentence(input);

        Assert.That(result, Is.EqualTo("lucky sentence"));
    }

    [Test]
    public void Test_QualifySentence_OddAsciiString_ReturnsCorrectMessage()
    {
        string input = "Hello!";

        string result = SentenceQualificator.QualifySentence(input);

        Assert.That(result, Is.EqualTo("unlucky sentence"));
    }
}   

