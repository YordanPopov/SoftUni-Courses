using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class BalancedBracketsTests
{
    [Test]
    public void Test_IsBalanced_EmptyInput_ShouldReturnTrue()
    {
        // Arrange
        string[] input = new string[] {};

        // Act
        bool actualResult = BalancedBrackets.IsBalanced(input);

        // Assert
        Assert.IsTrue(actualResult);
    }

    [Test]
    public void Test_IsBalanced_BalancedBrackets_ShouldReturnTrue()
    {
        // Arrange
        string[] input = new string[]  { "(", ")", "(", ")" } ;

        // Act
        bool actualResult = BalancedBrackets.IsBalanced(input);

        // Assert
        Assert.IsTrue(actualResult);
    }

    [Test]
    public void Test_IsBalanced_UnbalancedBrackets_ShouldReturnFalse()
    {
        // Arrange
        string[] input = new string[] { ")", "(", ")" };

        // Act
        bool actualResult = BalancedBrackets.IsBalanced(input);

        // Assert
        Assert.IsFalse(actualResult);
    }

    [Test]
    public void Test_IsBalanced_MoreClosingBrackets_ShouldReturnFalse()
    {
        // Arrange
        string[] input = new string[] { "(", ")", "(", ")", ")" };

        // Act
        bool actualResult = BalancedBrackets.IsBalanced(input);

        // Assert
        Assert.IsFalse(actualResult);
    }

    [Test]
    public void Test_IsBalanced_NoClosingBrackets_ShouldReturnFalse()
    {
        // Arrange
        string[] input = new string[] { "(", "(" };

        // Act
        bool actualResult = BalancedBrackets.IsBalanced(input);

        // Assert
        Assert.IsFalse(actualResult);
    }
}
