using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        Dictionary<string, int> testFruits = new()
        {
            ["apple"] = 100,
            ["pear"] = 10,
            ["orange"] = 110
        };

        string fruitName = "pear";

        // Act
        int actualResult = Fruits.GetFruitQuantity(testFruits, fruitName);

        // Assert
        Assert.That(actualResult, Is.EqualTo(10));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> testFruits = new()
        {
            ["apple"] = 100,
            ["pear"] = 10,
            ["orange"] = 110
        };

        string fruitName = "banana";

        // Act
        int actualResult = Fruits.GetFruitQuantity(testFruits, fruitName);

        // Assert
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> testFruits = new();
        string fruitName = "apple";

        // Act
        int actualResult = Fruits.GetFruitQuantity(testFruits, fruitName);

        // Assert
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> testFruits = null;
        string fruitName = "apple";

        // Act
        int actualResult = Fruits.GetFruitQuantity(testFruits, fruitName);

        // Assert
        Assert.That(actualResult, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> testFruits = new()
        {
            ["apple"] = 100,
            ["pear"] = 10,
            ["orange"] = 110
        };

        string fruitName = null;

        // Act
        int actualResult = Fruits.GetFruitQuantity(testFruits, fruitName);

        // Assert
        Assert.That(actualResult, Is.EqualTo(0));
    }
}
