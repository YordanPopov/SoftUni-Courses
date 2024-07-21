using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articles = 
            {
                "Article Content Author",
                "Article2 Content2 Author2",
                "Article3 Content3 Author3"
            };
        

        // Act
        Article result = this._article.AddArticles(articles);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        Article articles = new Article()
        {
            ArticleList = new()
            {
                new Article
                {
                    Title = "Article",
                    Content = "Content4",
                    Author = "Author3",
                },
                new Article
                {
                    Title = "Article3",
                    Content = "Content6",
                    Author = "Author2",
                },
                new Article
                {
                    Title = "Article2",
                    Content = "Content8",
                    Author = "Author4",
                }
            }
        };
        string expextedResult = "Article - Content4: Author3" + Environment.NewLine +
                                "Article2 - Content8: Author4" + Environment.NewLine +
                                "Article3 - Content6: Author2";

        // Act
        string actualResult = this._article.GetArticleList(articles, "title");
        
        // Assert
        Assert.That(actualResult, Is.EqualTo(expextedResult));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByContent()
    {
        // Arrange
        Article articles = new Article()
        {
            ArticleList = new()
            {
                new Article
                {
                    Title = "Article",
                    Content = "Content4",
                    Author = "Author3",
                },
                new Article
                {
                    Title = "Article3",
                    Content = "Content6",
                    Author = "Author2",
                },
                new Article
                {
                    Title = "Article2",
                    Content = "Content8",
                    Author = "Author4",
                }
            }
        };
        string expextedResult = "Article - Content4: Author3" + Environment.NewLine +
                                "Article3 - Content6: Author2" + Environment.NewLine +
                                "Article2 - Content8: Author4";

        // Act
        string actualResult = this._article.GetArticleList(articles, "content");

        // Assert
        Assert.That(actualResult, Is.EqualTo(expextedResult));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByAuthor()
    {
        // Arrange
        Article articles = new Article()
        {
            ArticleList = new()
            {
                new Article
                {
                    Title = "Article",
                    Content = "Content4",
                    Author = "Author3",
                },
                new Article
                {
                    Title = "Article3",
                    Content = "Content6",
                    Author = "Author2",
                },
                new Article
                {
                    Title = "Article2",
                    Content = "Content8",
                    Author = "Author4",
                }
            }
        };
        string expextedResult = "Article3 - Content6: Author2" + Environment.NewLine +
                                "Article - Content4: Author3" + Environment.NewLine +
                                "Article2 - Content8: Author4";

        // Act
        string actualResult = this._article.GetArticleList(articles, "author");

        // Assert
        Assert.That(actualResult, Is.EqualTo(expextedResult));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        Article articles = new Article()
        {
            ArticleList = new()
            {
                new Article
                {
                    Title = "Article",
                    Content = "Content4",
                    Author = "Author3",
                },
                new Article
                {
                    Title = "Article3",
                    Content = "Content6",
                    Author = "Author2",
                },
                new Article
                {
                    Title = "Article2",
                    Content = "Content8",
                    Author = "Author4",
                }
            }
        };

        // Act
        string actualResult = this._article.GetArticleList(articles, "test");

        // Assert
        Assert.That(actualResult, Is.Empty);
    }
}
