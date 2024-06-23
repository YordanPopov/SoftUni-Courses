using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests;

public class WordEraserTests
{
    [Test]
    public void Test_Erase_EmptyWordsList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> testList = new List<string>();
        string eraseWord = string.Empty;
        WordEraser eraser = new WordEraser();

        // Act
        string actualResult = eraser.Erase(testList, eraseWord);
        
        // Assert
        Assert.IsEmpty(actualResult);
        
    }

    [Test]
    public void Test_Erase_NullWordsList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> testList = null;
        string eraseWord = string.Empty;
        WordEraser eraser = new WordEraser();

        // Act
        string actualResult = eraser.Erase(testList, eraseWord);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_Erase_NullOrEmptyWordToErase_ShouldReturnStringOfGivenWordsList()
    {
        // Arrange
        List<string> testList = new List<string> { "test1", "test2", "test3" };
        string eraseWord = string.Empty;
        string expectedResult = "test1 test2 test3";
        WordEraser eraser = new WordEraser();

        // Act
        string actualResult = eraser.Erase(testList, eraseWord);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Erase_ValidInput_ShouldReturnEmptyString_WhenAllWordsMatchedTheWordToErase()
    {
        // Arrange
        List<string> testList = new List<string> { "test", "test", "test"};
        string eraseWord = "test";
        WordEraser eraser = new WordEraser();

        // Act
        string actualResult = eraser.Erase(testList, eraseWord);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_Erase_ValidInput_ShouldReturnStringWithoutErasedWords_WhenFewOfWordsMatchedWordToArese()
    {
        // Arrange
        List<string> testList = new List<string> { "test1", "test", "test2", "test"};
        string eraseWord = "test";
        string expectedResult = "test1 test2";
        WordEraser eraser = new WordEraser();

        // Act
        string actualResult = eraser.Erase(testList, eraseWord);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

