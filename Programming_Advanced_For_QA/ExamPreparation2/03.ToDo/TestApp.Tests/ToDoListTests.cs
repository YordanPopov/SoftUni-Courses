using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string taskTitle = "Test Task";
        DateTime taskDate = new DateTime(2024, 6, 14);
        this._toDoList.AddTask(taskTitle, taskDate);
        string expectedResult = "To-Do List:" + Environment.NewLine +
                                "[ ] Test Task - Due: 06/14/2024";

        // Act
        string actualResult = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string taskTitle = "Test Task";
        DateTime taskDate = new DateTime(2024, 6, 14);
        this._toDoList.AddTask(taskTitle, taskDate);
        this._toDoList.CompleteTask(taskTitle);
        string expectedResult = "To-Do List:" + Environment.NewLine +
                                "[✓] Test Task - Due: 06/14/2024";

        // Act
        string actualResult = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string taskTitle = "Test Task";
        DateTime taskDate = new DateTime(2024, 6, 14);
        this._toDoList.AddTask(taskTitle, taskDate);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => this._toDoList.CompleteTask("Invalid task"));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange
        string expectedResult = "To-Do List:";

        // Act
        string actualResult = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        string firstTaskTitle = "Test1 Task";
        string secondTaskTitle = "Test2 Task";
        DateTime firstTaskDate = new DateTime(2020, 1, 10);
        DateTime secondTaskDate = new DateTime(2024, 10, 10);

        this._toDoList.AddTask(firstTaskTitle, firstTaskDate);
        this._toDoList.AddTask(secondTaskTitle, secondTaskDate);
        this._toDoList.CompleteTask(secondTaskTitle);

        string expectedResult = "To-Do List:" + Environment.NewLine +
                                "[ ] Test1 Task - Due: 01/10/2020" + Environment.NewLine +
                                "[✓] Test2 Task - Due: 10/10/2024";

        // Act
        string actualResult = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
