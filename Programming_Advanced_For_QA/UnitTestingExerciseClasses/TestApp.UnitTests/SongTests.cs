using NUnit.Framework;

using System;
using System.Globalization;

namespace TestApp.UnitTests;

public class SongTests
{
    private Song _song;

    [SetUp]
    public void Setup()
    {
        this._song = new();
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsAllSongs_WhenWantedListIsAll()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = "all";
        string expectedResult = $"Song1{Environment.NewLine}Song2{Environment.NewLine}Song3";

        // Act
        string actualResult = this._song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsFilteredSongs_WhenWantedListIsSpecific()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = "Pop";
        string expectedResult = $"Song1{Environment.NewLine}Song3";

        // Act
        string actualResult = this._song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenNoSongsMatchWantedList()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = "Jazz";
        string expectedResult = string.Empty;

        // Act
        string actualResult = this._song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
