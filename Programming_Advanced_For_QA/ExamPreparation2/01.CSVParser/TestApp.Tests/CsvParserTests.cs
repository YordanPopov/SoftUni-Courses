using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        string input = string.Empty;
        string[] expectedResult = Array.Empty<string>();

        // Act
        string[] actualResult = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        string input = "Test";
        string[] expectedResult = new string[] { "Test" };

        // Act
        string[] actualResult = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        string input = "Test1,Test2,Test3,Test4";
        string[] expectedResult = new string[]
        {
            "Test1",
            "Test2",
            "Test3",
            "Test4"
        };

        // Act
        string[] actualResult = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        string input = " Test1  ,   Test2   ,  Test3 ,Test4    ";
        string[] expectedResult = new string[]
        {
            "Test1",
            "Test2",
            "Test3",
            "Test4"
        };

        // Act
        string[] actualResult = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}
