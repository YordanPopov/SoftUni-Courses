using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class BookCategoryTests : IDisposable
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
        public void Test_BookCategoryLifecycle()
        {
            // Step 1: Create a new book category
            var createCategoryRequest = new RestRequest("/category", Method.Post);
            createCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            createCategoryRequest.AddJsonBody(new
            {
                Title = "Fictional Literature"
            });

            var createCategoryResponse = client.Execute(createCategoryRequest);
            Assert.Multiple(() =>
            {
                Assert.That(createCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Failed to create a new category.");

                var content = JObject.Parse(createCategoryResponse.Content);
                Assert.That(content["_id"]?.ToString(), Is.Not.Null.Or.Empty,
                    "The response content does not contain a valid '_id'");
                Assert.That(content["title"]?.ToString(), Is.EqualTo("Fictional Literature"),
                    "The 'title' in the response does not match the expected value.");
            });

            string categoryId = JObject.Parse(createCategoryResponse.Content)["_id"].ToString();

            // Step 2: Retrieve all book categories and verify the newly created category is present
            var getAllCategoriesRequest = new RestRequest("/category");

            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            Assert.Multiple(() =>
            {
                Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Failed to retrieve all categories.");
                Assert.That(getAllCategoriesResponse.Content, Is.Not.Empty,
                    "The response content for retrieving all categories is empty.");

                var categories = JArray.Parse(getAllCategoriesResponse.Content);
                Assert.That(categories.Type, Is.EqualTo(JTokenType.Array),
                    "The response content is not an array.");
                Assert.That(categories.Count(), Is.GreaterThan(0),
                    "The response content does not contains categories.");

                var expectedCategory = categories.FirstOrDefault(c => c["title"].ToString() == "Fictional Literature");
                Assert.That(expectedCategory, Is.Not.Null.Or.Empty,
                    "The expected category with title 'Fictional Literature' is not present in the retrieved categories.");
                Assert.That(expectedCategory["_id"].ToString(), Is.EqualTo(categoryId),
                    "The 'id' of the expected category does not match the created category id.");
            });

            // Step 3: Update the category title
            var updateCategoryRequest = new RestRequest($"/category/{categoryId}", Method.Put);
            updateCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            updateCategoryRequest.AddJsonBody(new { Title = "Updated Fictional Literature" });

            var updateCategoryResponse = client.Execute(updateCategoryRequest);
            Assert.That(updateCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to update the category.");
            Assert.That(updateCategoryResponse.Content, Is.Not.Empty,
                "The response content for updating the category is empty.");

            // Step 4: Verify that the category details have been updated
            var verifyUpdateRequest = new RestRequest($"/category/{categoryId}");

            var verifyUpdateResponse = client.Execute(verifyUpdateRequest);
            Assert.Multiple(() =>
            {
                Assert.That(verifyUpdateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Failed to verify the updated category.");
                Assert.That(verifyUpdateResponse.Content, Is.Not.Empty,
                    "The response content for verifying the updated category is empty.");

                var updatedCategory = JObject.Parse(verifyUpdateResponse.Content);
                Assert.That(updatedCategory["title"].ToString(), Is.EqualTo("Updated Fictional Literature"),
                    "The 'title' of the updated category does not match the expected value.");
            });

            // Step 5: Delete the category and validate it's no longer accessible
            var deleteCategoryRequest = new RestRequest($"/category/{categoryId}", Method.Delete);
            deleteCategoryRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteCategoryResponse = client.Execute(deleteCategoryRequest);
            Assert.That(deleteCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to delete the category.");

            // Step 6: Verify that the deleted category cannot be found
            var verifyDeleteRequest = new RestRequest($"/category/{categoryId}");

            var verifyDeleteResponse = client.Execute(verifyDeleteRequest);
            Assert.That(verifyDeleteResponse.Content, Is.Null.Or.EqualTo("null"),
                "The deleted category is still accessible.");
    }
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
