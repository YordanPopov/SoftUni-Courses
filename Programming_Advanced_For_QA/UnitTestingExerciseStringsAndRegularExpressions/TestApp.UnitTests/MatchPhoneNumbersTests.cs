﻿using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchPhoneNumbersTests
{
    [Test]
    public void Test_Match_ValidPhoneNumbers_ReturnsMatchedNumbers()
    {
        // Arrange
        string phoneNumbers = "+359-2-124-5678, +359 2 986 5432, +359-2-555-5555";
        string expectedResult = "+359-2-124-5678, +359 2 986 5432, +359-2-555-5555";

        // Act
        string actualResult = MatchPhoneNumbers.Match(phoneNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Match_NoValidPhoneNumbers_ReturnsEmptyString()
    {
        // Arrange
        string phoneNumbers = "+359 2-124-5678, +359-2 986 5432, +359-2-555 5555";

        // Act
        string actualResult = MatchPhoneNumbers.Match(phoneNumbers);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string phoneNumbers = string.Empty;

        // Act
        string actualResult = MatchPhoneNumbers.Match(phoneNumbers);

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_Match_MixedValidAndInvalidNumbers_ReturnsOnlyValidNumbers()
    {
        // Arrange
        string phoneNumbers = "+359-2-124-5678, +359-2 986 5432, +359-2-555-5555";
        string expectedResult = "+359-2-124-5678, +359-2-555-5555";

        // Act
        string actualResult = MatchPhoneNumbers.Match(phoneNumbers);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
