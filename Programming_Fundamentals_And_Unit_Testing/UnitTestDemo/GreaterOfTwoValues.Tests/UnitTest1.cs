using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace GreaterOfTwoValues.Tests
{
    public class Tests
    {
        [TestCase(5, 10, 10)]
        [TestCase(10, 5, 10)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(-5, 10, 10)]
        [TestCase(10, -5, 10)]
        [TestCase(-1, 0, 0)]
        [TestCase(0, -1, 0)]
        [TestCase(-1, -10, -1)]
        [TestCase(-10, -1, -1)]
        public void Test_IntCompare_ReturnBiggerNumber(int num1, int num2, int expectedResult)
        {
            // Arrange
            
            // Act

            int actualResult = Program.IntCompare(num1, num2);
            

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}