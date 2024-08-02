using System;
using System.Collections.Generic;

using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["User_One"] = 2,
            ["User_Two"] = 4,
            ["User_Three"] = 3,
            ["User_Four"] = 6,
            ["User_Five"] = 5
        };

        string expectedResult = "User_Four with average grade 6.00" + Environment.NewLine +
                                "User_Five with average grade 5.00" + Environment.NewLine +
                                "User_Two with average grade 4.00";

        // Act
        string actualResult = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        Dictionary<string, int> grades = new();

        // Act
        string actualResult = Grades.GetBestStudents(grades);

        // Assert
        Assert.IsEmpty(actualResult);
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["User_One"] = 2,
            ["User_Two"] = 4,
        };

        string expectedResult = "User_Two with average grade 4.00" + Environment.NewLine +
                                "User_One with average grade 2.00";

        // Act
        string actualResult = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["User_Z"] = 3,
            ["User_S"] = 3,
            ["User_H"] = 3,
            ["User_G"] = 3,
            ["User_F"] = 3
        };

        string expectedResult = "User_F with average grade 3.00" + Environment.NewLine +
                                "User_G with average grade 3.00" + Environment.NewLine +
                                "User_H with average grade 3.00";

        // Act
        string actualResult = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
