using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class YellingCheckerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = string.Empty;

        // Act
        Dictionary<string, int> actualResult = YellingChecker.AnalyzeSentence(input);

        // Assert
        Assert.That(actualResult.Count, Is.EqualTo(0));
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyUpperCaseWords_ReturnsDictionaryWithYellingEntriesOnly()
    {
        // Arrange
        string input = "TEST THAT EXAM";

        Dictionary<string, int> expectedResult = new()
        {
            ["yelling"] = 3
        };

        // Act
        Dictionary<string, int> actualResult = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.IsTrue(actualResult.ContainsKey("yelling"));
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyLowerCaseWords_ReturnsDictionaryWithSpeakingLowerEntriesOnly()
    {
        // Arrange
        string input = "test that exam";

        Dictionary<string, int> expectedResult = new()
        {
            ["speaking lower"] = 3
        };

        // Act
        Dictionary<string, int> actualResult = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.IsTrue(actualResult.ContainsKey("speaking lower"));
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyMixedCaseWords_ReturnsDictionaryWithASpeakingNormalEntriesOnly()
    {
        // Arrange
        string input = "Test That Exam";

        Dictionary<string, int> expectedResult = new()
        {
            ["speaking normal"] = 3
        };

        // Act
        Dictionary<string, int> actualResult = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.IsTrue(actualResult.ContainsKey("speaking normal"));
    }

    [Test]
    public void Test_AnalyzeSentence_LowerUpperMixedCasesWords_ReturnsDictionaryWithAllTypeOfEntries()
    {
        // Arrange
        string input = "TEST That exam";

        Dictionary<string, int> expectedResult = new()
        {
            ["yelling"] = 1,
            ["speaking lower"] = 1,
            ["speaking normal"] = 1
        };

        // Act
        Dictionary<string, int> actualResult = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expectedResult, actualResult);
        Assert.That(actualResult, Has.Count.EqualTo(3));
        Assert.IsTrue(actualResult.ContainsKey("speaking normal"));
        Assert.IsTrue(actualResult.ContainsKey("speaking lower"));
        Assert.IsTrue(actualResult.ContainsKey("yelling"));
    }
}

