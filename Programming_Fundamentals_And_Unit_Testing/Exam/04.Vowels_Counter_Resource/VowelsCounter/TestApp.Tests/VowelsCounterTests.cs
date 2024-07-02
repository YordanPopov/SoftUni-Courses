using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests
{
    public class VowelsCounterTests
    {
        [Test]
        public void Test_CountTotalVowels_GetEmptyList_ReturnsZero()
        {
            // Arrange
            List<string> words = new List<string>();

            // Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            // Assert
            Assert.That(actualResult, Is.EqualTo(0));
        }

        [Test]
        public void Test_CountTotalVowels_GetListWithEmptyStringValues_ReturnsZero()
        {
            // Arrange
            List<string> words = new List<string>() { " ", " " };

            // Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            // Assert
            Assert.That(actualResult, Is.EqualTo(0));
        }

        [Test]
        public void Test_CountTotalVowels_MultipleLowerCaseStrings_ReturnsVowelsCount()
        {
            // Arrange
            List<string> words = new List<string>() { "softuni", "test", "exam" };
            int expectedResult = 6;

            // Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_CountTotalVowels_GetStringsWithNoVowels_ReturnsZero()
        {
            // Arrange
            List<string> words = new List<string>() { "JS", "DB", "C#", "C++" };

            // Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            // Assert
            Assert.That(actualResult, Is.EqualTo(0));
        }

        [Test]
        public void Test_CountTotalVowels_StringsWithMixedCaseVowels_ReturnsVowelsCount()
        {
            // Arrange
            List<string> words = new List<string>() { "SoftUni", "tEst", "Exam" };
            int expectedResult = 6;

            // Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}

