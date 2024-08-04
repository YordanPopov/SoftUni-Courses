using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class EmployeeManagementSystemTests
{
    private EmployeeManagementSystem _employeeManagementSystem;

    [SetUp]
    public void SetUp()
    {
        this._employeeManagementSystem = new EmployeeManagementSystem();
    }

    [Test]
    public void Test_Constructor_CheckInitialEmptyEmployeeCollectionAndCount()
    {
        // Act
        List<string> actualResult = this._employeeManagementSystem.GetAllEmployees();

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(0));
        Assert.That(this._employeeManagementSystem.EmployeeCount, Is.EqualTo(0));
    }

    [Test]
    public void Test_AddEmployee_ValidEmployeeName_AddNewEmployee()
    {
        // Arrange
        this._employeeManagementSystem.AddEmployee("Tester1");

        // Act
        List<string> actualResult = this._employeeManagementSystem.GetAllEmployees();

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult[0], Is.EqualTo("Tester1"));
    }

    [Test]
    public void Test_AddEmployee_NullOrEmptyEmployeeName_ThrowsArgumentException()
    {
        // Arrange
        string employeeName1 = "   ";
        string employeeName2 = string.Empty;
        string employeeName3 = null;

        // Act && Assert
        Assert.That(() => this._employeeManagementSystem.AddEmployee(employeeName1), Throws.ArgumentException.With.Message.EqualTo("Employee name cannot be empty or whitespace."));
        Assert.That(() => this._employeeManagementSystem.AddEmployee(employeeName2), Throws.ArgumentException.With.Message.EqualTo("Employee name cannot be empty or whitespace."));
        Assert.That(() => this._employeeManagementSystem.AddEmployee(employeeName3), Throws.ArgumentException.With.Message.EqualTo("Employee name cannot be empty or whitespace."));
    }

    [Test]
    public void Test_RemoveEmployee_ValidEmployeeName_RemoveFirstEmployeeName()
    {
        // Arrange
        this._employeeManagementSystem.AddEmployee("Tester1");
        this._employeeManagementSystem.AddEmployee("Tester2");

        this._employeeManagementSystem.RemoveEmployee("Tester1");

        // Act 
        List<string> actualResult = this._employeeManagementSystem.GetAllEmployees();

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(1));
        Assert.That(actualResult[0], Is.EqualTo("Tester2"));
    }

    [Test]
    public void Test_RemoveEmployee_NullOrEmptyEmployeeName_ThrowsArgumentException()
    {
        // Arrange
        string employeeName1 = "   ";
        string employeeName2 = string.Empty;
        string employeeName3 = null;

        // Act && Assert
        Assert.That(() => this._employeeManagementSystem.RemoveEmployee(employeeName1), Throws.ArgumentException.With.Message.EqualTo("Employee not found in the system."));
        Assert.That(() => this._employeeManagementSystem.RemoveEmployee(employeeName2), Throws.ArgumentException.With.Message.EqualTo("Employee not found in the system."));
        Assert.That(() => this._employeeManagementSystem.RemoveEmployee(employeeName3), Throws.ArgumentException.With.Message.EqualTo("Employee not found in the system."));
    }

    [Test]
    public void Test_GetAllEmployees_AddedAndRemovedEmployees_ReturnsExpectedEmployeeCollection()
    {
        // Arrange
        this._employeeManagementSystem.AddEmployee("Tester1");
        this._employeeManagementSystem.AddEmployee("Tester2");
        this._employeeManagementSystem.AddEmployee("Tester3");
        this._employeeManagementSystem.AddEmployee("Tester4");

        this._employeeManagementSystem.RemoveEmployee("Tester1");
        this._employeeManagementSystem.RemoveEmployee("Tester3");

        // Act 
        List<string> actualResult = this._employeeManagementSystem.GetAllEmployees();

        // Assert
        Assert.That(actualResult, Has.Count.EqualTo(2));
        Assert.That(actualResult[0], Is.EqualTo("Tester2"));
        Assert.That(actualResult[1], Is.EqualTo("Tester4"));
    }   
}

