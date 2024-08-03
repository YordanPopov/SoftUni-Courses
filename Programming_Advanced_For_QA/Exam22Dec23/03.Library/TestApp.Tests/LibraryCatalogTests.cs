using NUnit.Framework;
using System;
using TestApp.Library;

namespace TestApp.Tests;

[TestFixture]
public class LibraryCatalogTests
{
    private LibraryCatalog _catalog = null!;

    [SetUp]
    public void SetUp()
    {
        this._catalog = new();
    }

    [Test]
    public void Test_AddBook_BookAddedToCatalog()
    {
        // Arrange
        this._catalog.AddBook("978", "Carrie", "Stephen King" );

        string expectedResult = "Library Catalog:" + Environment.NewLine +
                                "Carrie by Stephen King (ISBN: 978)";

        // Act
        string actualResult = this._catalog.DisplayCatalog();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetBook_BookExists_ReturnsBook()
    {
        // Arrange
        this._catalog.AddBook("978", "Carrie", "Stephen King");

        // Act
        Book actualResult = this._catalog.GetBook("978");

        // Assert
        Assert.That(actualResult.Title, Is.EqualTo("Carrie"));
        Assert.That(actualResult.Author, Is.EqualTo("Stephen King"));
    }

    [Test]
    public void Test_GetBook_BookDoesNotExist_ThrowsArgumentException()
    {
        // Arrange
        this._catalog.AddBook("978", "Carrie", "Stephen King");

        // Act && Assert
        //Assert.Throws<ArgumentException>(() => this._catalog.GetBook("123"));
        Assert.That(() => this._catalog.GetBook("123"), Throws.ArgumentException.With.Message.EqualTo("Book with given ISBN does not exist."));
    }

    [Test]
    public void Test_DisplayCatalog_NoBooks_ReturnsEmptyString()
    {
        // Act
        string actualResult = this._catalog.DisplayCatalog();

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_DisplayCatalog_WithBooks_ReturnsFormattedCatalog()
    {
        // Arrange
        this._catalog.AddBook("978-0-385-08695-0", "Carrie", "Stephen King");
        this._catalog.AddBook("978-0-451-08754-6", "The Long Walk", "Stephen King");

        string expectedResult = "Library Catalog:" + Environment.NewLine +
                                "Carrie by Stephen King (ISBN: 978-0-385-08695-0)" + Environment.NewLine +
                                "The Long Walk by Stephen King (ISBN: 978-0-451-08754-6)";

        // Act
        string actualResult = this._catalog.DisplayCatalog();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
