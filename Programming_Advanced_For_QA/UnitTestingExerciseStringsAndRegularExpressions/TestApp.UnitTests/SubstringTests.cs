using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{
    // TODO: finish the test
    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        // Arrange
        string toRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown jumps over the lazy dog";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        // Arrange
        string toRemove = "the";
        string input = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "quick brown fox jumps over lazy dog";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        // Arrange
        string toRemove = "dog";
        string input = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown fox jumps over the lazy";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        // Arrange
        string toRemove = "Test";
        string input = "Test test Test test test Test";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.IsEmpty(actualResult);
    }
}
