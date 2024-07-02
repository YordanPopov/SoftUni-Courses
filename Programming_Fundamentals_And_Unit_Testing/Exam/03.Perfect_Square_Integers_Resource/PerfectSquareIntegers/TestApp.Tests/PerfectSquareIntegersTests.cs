using NUnit.Framework;

namespace TestApp.Tests
{
    public class PerfectSquareIntegersTests
    {
        [Test]
        public void Test_FindPerfectSquares_StartNumberGreaterThanEndNumber_ReturnsErrorMessage()
        {
            // Arrange
            int startNumber = 10;
            int endNumber = 1;
            string expectedResult = "Start number should be less than end number.";

            // Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_FindPerfectSquares_GetSingleSquareInteger_ReturnsSameSquareInteger()
        {
            // Arrange
            int startNumber = 1;
            int endNumber = 1;
            string expectedResult = "1";

            // Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_FindPerfectSquares_GetZeroAsSingleInteger_ReturnsZero()
        {
            // Arrange
            int startNumber = 0;
            int endNumber = 0;
            string expectedResult = "0";

            // Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_FindPerfectSquares_RangeIncludesMultiplePerfectSquares_RetursOnlySquareIntegers()
        {
            // Arrange
            int startNumber = 1;
            int endNumber = 50;
            string expectedResult = "1 4 9 16 25 36 49";

            // Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_FindPerfectSquares_NoPerfectSquaresInRange_ReturnsEmptyString()
        {
            // Arrange
            int startNumber = 2;
            int endNumber = 3;

            // Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.That(actualResult, Is.Empty);
        }
    }
}

