using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class ExtractFileTests
{
    [Test]
    public void Test_GetFile_NullPath_ThrowsArgumentNullException()
    {
        // Arrange
        string nullPath = null;

        // Act & Asssert
        Assert.That(() => ExtractFile.GetFile(nullPath), Throws.ArgumentNullException); 
    }

    [Test]
    public void Test_GetFile_EmptyPath_ThrowsArgumentNullException()
    {
        // Arrange
        string emptyPath = string.Empty;

        // Act & Asssert
        Assert.That(() => ExtractFile.GetFile(emptyPath), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_GetFile_ValidPath_ReturnsFileNameAndExtension()
    {
        // Arrange
        string validPath = "C:\\User\\test.unittest";
        string expectedResult = "File name: test\nFile extension: unittest";

        // Act
        string actualResult = ExtractFile.GetFile(validPath);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetFile_PathWithNoExtension_ReturnsFileNameOnly()
    {
        // Arrange
        string noExtentionPath = "C:\\User\\test";
        string expectedResult = "File name: test";

        // Act
        string actualResult = ExtractFile.GetFile(noExtentionPath);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetFile_PathWithSpecialCharacters_ReturnsFileNameAndExtension()
    {
        // Arrange
        string validPath = "C:\\@@&^@&*\\test.unittest";
        string expectedResult = "File name: test\nFile extension: unittest";

        // Act
        string actualResult = ExtractFile.GetFile(validPath);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
