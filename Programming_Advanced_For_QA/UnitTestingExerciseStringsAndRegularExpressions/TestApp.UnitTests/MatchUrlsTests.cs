using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string? input = string.Empty;

        // Act
        List<string> actualResult = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string input = "Invalid Urls";

        // Act
        List<string> actualResult = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string input = "https://www.Google.bg";
        List<string> expectedResult = new() { "https://www.Google.bg" };

        // Act
        List<string> actualResult = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string input = "https://www.Google.bg http://app.Google.bg https://Google.com";
        List<string> expectedResult = new() { "https://www.Google.bg", "http://app.Google.bg", "https://Google.com"};

        // Act
        List<string> actualResult = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string input = "A valid URL: \"https://www.Google.bg\"";
        List<string> expectedResult = new() { "https://www.Google.bg" };

        // Act
        List<string> actualResult = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}
