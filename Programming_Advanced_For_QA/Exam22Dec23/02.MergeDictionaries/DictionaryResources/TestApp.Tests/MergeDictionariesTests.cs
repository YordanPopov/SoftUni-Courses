using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class MergeDictionariesTests
{
    [Test]
    public void Test_Merge_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actualResult = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Merge_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsNonEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>();

        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        // Act
        Dictionary<string, int> actualResult = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(3));
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_Merge_TwoNonEmptyDictionaries_ReturnsMergedDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            ["Four"] = 4,
            ["Five"] = 5,
            ["Six"] = 6
        };

        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3,
            ["Four"] = 4,
            ["Five"] = 5,
            ["Six"] = 6
        };

        // Act
        Dictionary<string, int> actualResult = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(6));
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_Merge_OverlappingKeys_ReturnsMergedDictionaryWithValuesFromDict2()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            ["Two"] = 4,
            ["Three"] = 5,
            ["Six"] = 6
        };

        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            ["One"] = 1,
            ["Two"] = 4,
            ["Three"] = 5,
            ["Six"] = 6
        };

        // Act
        Dictionary<string, int> actualResult = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(4));
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}
