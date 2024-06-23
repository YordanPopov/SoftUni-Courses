using NUnit.Framework;

namespace TestApp.Tests
{
    public class HashTagCheckerTests
    {
        [Test]
        public void Test_GetHashTags_ValidTextWithOneHashTag_ReturnMessageForOneHashTags()
        {
            // Arrange
            string text = "#QA - mastering the unit testing";
            string expectedResult = "Only one! You know exactly what you #tag.";

            // Act
            string actualResult = HashTagChecker.GetHashTags(text);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_GetHashTags_ValidText_ReturnMessageForEvenHashTags()
        {
            // Arrange
            string text = "#SoftUni have #QA courses.";
            string expectedResult = "The text contains an even number of #tags (2 in total).";

            // Act
            string actualResult = HashTagChecker.GetHashTags(text);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_GetHashTags_ValidText_ReturnMessageForOddHashTags()
        {
            // Arrange
            string text = "#Unit #tests are best practice for #QA beginners.";
            string expectedResult = "The text contains an odd number of #tags (3 in total).";

            // Act
            string actualResult = HashTagChecker.GetHashTags(text);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_GetHashTags_NullOrEmptyText_ReturnsErrorMessage()
        {
            // Arrange
            string text = string.Empty;
            string expectedResult = "No content...";

            // Act
            string actualResult = HashTagChecker.GetHashTags(text);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_GetHashTags_TestWithoutHashTags_ReturnsErrorMessage()
        {
            // Arrange
            string text = "This text contains no tags.";
            string expectedResult = "The text does not contain #tags.";

            // Act
            string actualResult = HashTagChecker.GetHashTags(text);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}

