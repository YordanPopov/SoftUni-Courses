using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class BookTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("john.doe@example.com", "password123");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token should not be null or empty");
        }

        [Test]
        public void Test_GetAllBooks()
        {
            var getAllBooksRequest = new RestRequest("/book"); // Method.Get by default

            var getAllBooksResponse = client.Execute(getAllBooksRequest);

            Assert.Multiple(() =>
            {
                Assert.That(getAllBooksResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Failed to retrieve books.");
                Assert.That(getAllBooksResponse.Content, Is.Not.Empty,
                    "The response content for retrieving books is empty.");

                var books = JArray.Parse(getAllBooksResponse.Content);
                Assert.That(books.Type, Is.EqualTo(JTokenType.Array),
                    "The response content is not an array.");
                Assert.That(books.Count(), Is.GreaterThan(0),
                    "The response does not contains books.");

                foreach (var book in books)
                {
                    Assert.That(book["title"]?.ToString(), Is.Not.Null.Or.Empty,
                        "A book entry has an empty or null 'title'.");
                    Assert.That(book["author"]?.ToString(), Is.Not.Null.Or.Empty,
                        "A book entry has an empty or null 'author'.");
                    Assert.That(book["description"]?.ToString(), Is.Not.Null.Or.Empty,
                        "A book entry has an empty or null 'description'.");
                    Assert.That(book["price"]?.ToString(), Is.Not.Null.Or.Empty,
                        "A book entry has an empty or null 'price'.");
                    Assert.That(book["pages"]?.ToString(), Is.Not.Null.Or.Empty,
                        "A book entry has an empty or null 'pages'.");
                    Assert.That(book["category"]?.ToString(), Is.Not.Null.Or.Empty,
                        "A book entry has an empty or null 'category'.");
                }
            });
        }

        [Test]
        public void Test_GetBookByTitle()
        {
            var getAllBooksRequest = new RestRequest("/book");

            var getAllBooksResponse = client.Execute(getAllBooksRequest);
            Assert.That(getAllBooksResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to retrieve books.");
            Assert.That(getAllBooksResponse.Content, Is.Not.Empty,
                "The response content for retrieving books is empty.");

            var books = JArray.Parse(getAllBooksResponse.Content);
            var expectedBook = books.FirstOrDefault(b => b["title"]?.ToString() == "The Great Gatsby");
            Assert.That(expectedBook, Is.Not.Null.Or.Empty,
                "The book 'The Great Gatsby' is not found in the retrieved books.");
            Assert.That(expectedBook["title"]?.ToString(), Is.EqualTo("The Great Gatsby"),
                "The 'title' of the book does not match expected value.");
            Assert.That(expectedBook["author"]?.ToString(), Is.EqualTo("F. Scott Fitzgerald"),
                "The 'author' of the book does not match expected value.");
        }

        [Test]
        public void Test_AddBook()
        {
            // Get all categories
            var getAllCategoriesRequest = new RestRequest("/category");

            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            Assert.That(getAllCategoriesResponse.IsSuccessful, Is.True,
                "Failed to retrieve categories");
            Assert.That(getAllCategoriesResponse.Content, Is.Not.Null.Or.Empty,
                "The response content for retrieving categories is empty.");

            var categories = JArray.Parse(getAllCategoriesResponse.Content);

            string categoryId = categories.First()["_id"].ToString();

            // Create a new book
            var payload = new
            {
                Title = "Test book",
                Author = "Test author",
                Description = "Test description",
                Price = 11.90,
                Pages = 100,
                Category = categoryId
            };

            var createBookRequest = new RestRequest("/book", Method.Post);
            createBookRequest.AddHeader("Authorization", $"Bearer {token}");
            createBookRequest.AddJsonBody(payload);

            var createBookResponse = client.Execute(createBookRequest);
            Assert.That(createBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to add the book.");
            Assert.That(createBookResponse.Content, Is.Not.Empty,
                "The response content for adding the book is empty.");

            string bookId = JObject.Parse(createBookResponse.Content)["_id"]?.ToString();
            Assert.That(bookId, Is.Not.Null.Or.Empty,
                "The response content does not contain a valid '_id' for the added book.");

            // Get details of the book
            var getBookByIdRequest = new RestRequest("/book/{id}");
            getBookByIdRequest.AddUrlSegment("id", bookId);

            var getBookByIdResponse = client.Execute(getBookByIdRequest);
            Assert.Multiple(() =>
            {
                Assert.That(getBookByIdResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Failed to retrieve the added book by ID.");
                Assert.That(getBookByIdResponse.Content, Is.Not.Empty,
                    "The response content for retrieving the added book is empty.");

                var book = JObject.Parse(getBookByIdResponse.Content);
                Assert.That(book["title"].ToString(), Is.EqualTo(payload.Title),
                    "The 'title' of the added book does not match the expected value.");
                Assert.That(book["author"].ToString(), Is.EqualTo(payload.Author),
                    "The 'author' of the added book does not match the expected value.");
                Assert.That(book["price"].Value<decimal>, Is.EqualTo(payload.Price),
                    "The 'price' of the added book does not match the expected value.");
                Assert.That(book["pages"].Value<int>, Is.EqualTo(payload.Pages),
                    "The 'pages' of the added book do not match the expected value.");
                Assert.That(book["category"].ToString(), Is.Not.Empty,
                    "The 'category' of the added book is empty.");
                Assert.That(book["category"]["_id"].ToString(), Is.EqualTo(categoryId),
                    "The 'category' ID of the added book does not match the expected value.");
            });
        }

        [Test]
        public void Test_UpdateBook()
        {
            // Get all books
            var getAllBooksRequest = new RestRequest("/book");

            var getAllBooksResponse = client.Execute(getAllBooksRequest);
            Assert.That(getAllBooksResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to retrieve books.");
            Assert.That(getAllBooksResponse.Content, Is.Not.Empty,
                "The response content for retrieving books is empty.");

            var books = JArray.Parse(getAllBooksResponse.Content);
            var bookToUpdate = books.FirstOrDefault(b => b["title"]?.ToString() == "The Catcher in the Rye");
            Assert.That(bookToUpdate, Is.Not.Null.Or.Empty,
                "The book 'The Catcher in the Rye' is not found in the retrieved books.");
            Assert.That(bookToUpdate["title"].ToString(), Is.EqualTo("The Catcher in the Rye"),
                "The 'title' of the book to update does not match 'The Catcher in the Rye'.");

            string bookId = bookToUpdate["_id"].ToString();

            // Update book
            var updateBookRequest = new RestRequest("/book/{id}", Method.Put);
            updateBookRequest.AddHeader("Authorization", $"Bearer {token}");
            updateBookRequest.AddUrlSegment("id", bookId);
            updateBookRequest.AddJsonBody(new
            {
                Title = "Updated Book Title",
                Author = "Updated Author"
            });

            var updateBookResponse = client.Execute(updateBookRequest);
            Assert.Multiple(() =>
            {
                Assert.That(updateBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Failed to update the book.");
                Assert.That(updateBookResponse.Content, Is.Not.Empty,
                    "The response content for updating the book is empty.");

                var updatedBook = JObject.Parse(updateBookResponse.Content);
                Assert.That(updatedBook["title"].ToString(), Is.EqualTo("Updated Book Title"),
                    "The 'title' of the updated book does not match the expected value.");
                Assert.That(updatedBook["author"].ToString(), Is.EqualTo("Updated Author"),
                    "The 'author' of the updated book does not match the expected value.");
            });
        }

        [Test]
        public void Test_DeleteBook()
        {
            // Get all books
            var getAllBooksRequest = new RestRequest("/book");

            var getAllBooksResponse = client.Execute(getAllBooksRequest);
            Assert.That(getAllBooksResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to retrieve books.");
            Assert.That(getAllBooksResponse.Content, Is.Not.Empty,
                "The response content for retrieving books is empty.");

            var books = JArray.Parse(getAllBooksResponse.Content);
            var bookToDelete = books.FirstOrDefault(b => b["title"]?.ToString() == "To Kill a Mockingbird");
            Assert.That(bookToDelete, Is.Not.Null.Or.Empty,
                "The book 'To Kill a Mockingbird' is not found in the retrieved books.");
            Assert.That(bookToDelete["title"].ToString(), Is.EqualTo("To Kill a Mockingbird"),
                "The 'title' of the book to delete does not match 'To Kill a Mockingbird'.");

            string bookId = bookToDelete["_id"].ToString();

            // Delete book
            var deleteBookRequest = new RestRequest("/book/{id}", Method.Delete);
            deleteBookRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteBookRequest.AddUrlSegment("id", bookId);

            var deleteBookResponse = client.Execute(deleteBookRequest);
            Assert.That(deleteBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to delete the book.");

            // Get details of the deleted book
            var verifyDeleteRequest = new RestRequest("/book/{id}");
            verifyDeleteRequest.AddUrlSegment("id", bookId);

            var verifyDeleteResponse = client.Execute(verifyDeleteRequest);
            Assert.That(verifyDeleteResponse.Content, Is.Null.Or.EqualTo("null"),
                "The deleted book is still accessible.");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
