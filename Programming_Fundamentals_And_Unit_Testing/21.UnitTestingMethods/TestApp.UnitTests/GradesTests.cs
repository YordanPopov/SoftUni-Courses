using NUnit.Framework;

namespace TestApp.UnitTests;

public class GradesTests
{
    [TestCase(2.5, "Fail")]
    [TestCase(3.3, "Average")]
    [TestCase(3.8, "Good")]
    [TestCase(4.2, "Very Good")]
    [TestCase(4.8, "Excellent")]
    [TestCase(6, "Invalid!")]
    public void Test_GradeAsWords_ReturnsCorrectString(double grade, string expected)
    {
        // Arrange

        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase(2, "Fail")]
    [TestCase(2.01, "Fail")]
    [TestCase(2.99, "Fail")]
    [TestCase(3, "Average")]
    [TestCase(3.01, "Average")]
    [TestCase(3.49, "Average")]
    [TestCase(3.50, "Good")]
    [TestCase(3.51, "Good")]
    [TestCase(3.99, "Good")]
    [TestCase(4, "Very Good")]
    [TestCase(4.01, "Very Good")]
    [TestCase(4.49, "Very Good")]
    [TestCase(4.50, "Excellent")]
    [TestCase(4.51, "Excellent")]
    [TestCase(4.99, "Excellent")]
    [TestCase(0, "Invalid!")]
    [TestCase(1.99, "Invalid!")]
    [TestCase(5.01, "Invalid!")]
    [TestCase(10, "Invalid!")]
    public void Test_GradeAsWords_ReturnsCorrectString_EdgeCases(double grade, string expected)
    {
        // Arrange

        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
