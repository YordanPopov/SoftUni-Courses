using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class CategoryTests : IDisposable
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
        public void Test_CategoryLifecycle_RecipeBook()
        {
            // Step 1: Create a new category
            var createCategoryRequest = new RestRequest("/category", Method.Post);
            createCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            createCategoryRequest.AddJsonBody(new {
                Name = "Vegan Recipes"
            });

            var createCategoryResponse = client.Execute(createCategoryRequest);

            Assert.That(createCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Creating category request is failed");
            Assert.That(createCategoryResponse.Content, Is.Not.Null.Or.Empty,
                "Creating response body content is null or empty");

            var responseContent = JObject.Parse(createCategoryResponse.Content);
            Assert.That(responseContent["_id"]?.ToString(), Is.Not.Null.Or.Empty,
                "Created category ID is null or empty");

            // Step 2: Get all categories and verify new category is included
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting all categories is failed");
            Assert.That(getAllCategoriesResponse.Content, Is.Not.Null.Or.Empty,
                "Getting all categories response body content is null or empty");

            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            Assert.That(categories.Type, Is.EqualTo(JTokenType.Array),
                "Response type is not an array");
            Assert.That(categories, Has.Count.GreaterThan(0),
                "The array is empty");

            var expectedCategory = categories.FirstOrDefault(c => c["name"]?.ToString() == "Vegan Recipes");
            Assert.That(expectedCategory, Is.Not.Null.Or.Empty,
                "Expected category not found");

            var categoryId = expectedCategory["_id"]?.ToString();
            Assert.That(categoryId, Is.Not.Null.Or.Empty,
                "Category ID is null or empty");
            
            // Step 3: Get category by ID
            var getCategoryRequest = new RestRequest($"/category/{categoryId}", Method.Get);

            var getCategoryResponse = client.Execute(getCategoryRequest);
            Assert.That(getCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting category by ID is failed");
            Assert.That(getCategoryResponse.Content, Is.Not.Null.Or.Empty,
                "Getting category by ID response body content is null or empty");

            var returnedCategory = JObject.Parse(getCategoryResponse.Content);
            Assert.That(returnedCategory, Is.Not.Null.Or.Empty,
                "There no returned category");
            Assert.That(returnedCategory["name"]?.ToString(), Is.EqualTo("Vegan Recipes"),
                "Category name does not match the expected value");
            Assert.That(returnedCategory["_id"]?.ToString(), Is.EqualTo(categoryId),
                "Category ID does not match expected ID");

            // Step 4: Edit the category and verify update
            var updateCategoryRequest = new RestRequest($"/category/{categoryId}", Method.Put);
            updateCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            updateCategoryRequest.AddJsonBody(new
            {
                Name = "Healthy Vegan Recipes"
            });

            var updateCategoryResponse = client.Execute(updateCategoryRequest);
            Assert.That(updateCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Updating category is failed");
            Assert.That(updateCategoryResponse.Content, Is.Not.Null.Or.Empty,
                "Updating category response body content is null or empty");

            // Verify category is updated
            var verifyUpdateRequest = new RestRequest($"/category/{categoryId}", Method.Get);

            var verifyUpdateResponse = client.Execute(verifyUpdateRequest);
            Assert.That(verifyUpdateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting updated category is failed");
            Assert.That(verifyUpdateResponse.Content, Is.Not.Null.Or.Empty,
                "Verify category update response body is null or empty");

            var updatedCategory = JObject.Parse(verifyUpdateResponse.Content);
            Assert.That(updatedCategory["name"]?.ToString(), Is.EqualTo("Healthy Vegan Recipes"),
                "Updated category name does not match the input");

            // Step 5: Attempt to update category with invalid data (negative test)
            var invalidDataUpdateRequest = new RestRequest($"/category/{categoryId}", Method.Put);
            invalidDataUpdateRequest.AddHeader("Authorization", $"Bearer {token}");
            invalidDataUpdateRequest.AddJsonBody(new
            {
                _id = "InvalidID"
            });

            var invalidDataUpdateResponse = client.Execute(invalidDataUpdateRequest);
            Assert.That(invalidDataUpdateResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError),
                "Updating category with invalid data is successful");

            // Step 6: Delete the category
            var deleteCategoryRequest = new RestRequest($"/category/{categoryId}", Method.Delete);
            deleteCategoryRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteCategoryResponse = client.Execute(deleteCategoryRequest);
            Assert.That(deleteCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Deleting category is failed");

            // Step 7: Verify category is deleted
            var verifyDeleteRequest = new RestRequest($"/category/{categoryId}", Method.Get);

            var verifyDeleteResponse = client.Execute(verifyDeleteRequest);
            Assert.That(verifyDeleteResponse.Content, Is.Null.Or.EqualTo("null"),
                "Verifing delete response is not null");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
