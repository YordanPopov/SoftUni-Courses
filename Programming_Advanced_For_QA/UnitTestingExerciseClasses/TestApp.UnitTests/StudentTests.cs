using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class StudentTests
{
    private Student _student;

    [SetUp]
    public void SetUp()
    {
        this._student = new();
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia" };
        string wantedTown = "Sofia";
        string expectedResult = $"John Doe is 25 years old.{Environment.NewLine}Alice Johnson is 20 years old.";

        // Act
        string actualResult = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityDoesNotExist()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia" };
        string wantedTown = "Isperih";
        string expectedResult = $"John Doe is 25 years old.{Environment.NewLine}Alice Johnson is 20 years old.";

        // Act
        string actualResult = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenNoStudentsGiven()
    {
        // Arrange
        string[] students = Array.Empty<string>();
        string wantedTown = "Isperih";
        string expectedResult = $"John Doe is 25 years old.{Environment.NewLine}Alice Johnson is 20 years old.";

        // Act
        string actualResult = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }
}
