using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]
    public void SetUp()
    {
        this._person = new Person();
    }

    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Yordan Y003 30", "Alice A001 35", "Yordan Y003 32", "TestUser T00T 100" };
        List<Person> expectedPeopleList = new List<Person>()
            {
                new Person
                {
                    Name = "Alice",
                    Id = "A001",
                    Age = 35
                },
                new Person
                {
                    Name = "Bob",
                    Id = "B002",
                    Age = 30
                },
                new Person
                {
                    Name = "Yordan",
                    Id = "Y003",
                    Age = 32
                },
                new Person
                {
                    Name = "TestUser",
                    Id = "T00T",
                    Age = 100
                }
            };

        // Act
        List<Person> actualPeopleList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(actualPeopleList, Has.Count.EqualTo(4));
        for (int i = 0; i < actualPeopleList.Count; i++)
        {
            Assert.That(actualPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(actualPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(actualPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        List<Person> people = new List<Person>()
        {
            new Person
            {
                Name = "Yordan",
                Id = "Y0032",
                Age = 32
            },
            new Person
            {
                Name = "Petkan",
                Id = "P0030",
                Age = 30
            },
            new Person
            {
                Name = "Svetoslav",
                Id = "S0040",
                Age = 40
            }
        };
        string expectedResult = "Petkan with ID: P0030 is 30 years old." + Environment.NewLine +
                                "Yordan with ID: Y0032 is 32 years old." + Environment.NewLine +
                                "Svetoslav with ID: S0040 is 40 years old.";
        // Act
        string actualResult = this._person.GetByAgeAscending(people);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
