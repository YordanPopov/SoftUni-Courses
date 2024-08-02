using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new();
        Dictionary<string, int> dict2 = new();

        // Act
        Dictionary<string, int> actualResult = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsEmpty(actualResult);
        CollectionAssert.IsEmpty(actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3,
        };
        Dictionary<string, int> dict2 = new();

        // Act
        Dictionary<string, int> actualResult = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        Dictionary<string, int> dict2 = new()
        {
            ["Four"] = 4,
            ["Five"] = 5,
            ["Six"] = 6
        };

        // Act
        Dictionary<string, int> actualResult = DictionaryIntersection.Intersect(dict1 , dict2);

        // Assert
        Assert.That(actualResult.Count, Is.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        Dictionary<string, int> dict2 = new()
        {
            ["Two"] = 2,
            ["Three"] = 3,
            ["Six"] = 6
        };

        Dictionary<string, int> expectedResult = new()
        {
            ["Two"] = 2,
            ["Three"] = 3
        };

        // Act
        Dictionary<string, int> actualResult = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(actualResult.Count, Is.EqualTo(2));
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        Dictionary<string, int> dict2 = new()
        {
            ["Two"] = 4,
            ["Three"] = 5,
            ["Six"] = 6
        };

        // Act
        Dictionary<string, int> actualResult = DictionaryIntersection.Intersect(dict1 , dict2);

        // Assert
        Assert.That(actualResult.Count, Is.EqualTo(0));
    }
}
