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
        public void Test_CategoryLifecycle()
        {
            // Step 1: Create a new category
            var createNewCategoryRequest = new RestRequest("/category", Method.Post);
            createNewCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            createNewCategoryRequest.AddJsonBody(new { Name = "Test Category" });

            var createNewCategoryResponse = client.Execute(createNewCategoryRequest);
            Assert.That(createNewCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(createNewCategoryResponse.Content, Is.Not.Null.Or.Empty,
                "Response content is null or empty");

            string categoryId = JObject.Parse(createNewCategoryResponse.Content)["_id"].ToString();
            Assert.That(categoryId, Is.Not.Null.Or.Empty,
                "The Category ID is null or empty!");

            // Step 2: Get all categories
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(getAllCategoriesResponse.Content, Is.Not.Empty,
                "Response content is empty!");

            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            Assert.That(categories.Type, Is.EqualTo(JTokenType.Array),
                "Response content is not an array!");
            Assert.That(categories.Count, Is.GreaterThan(0),
                "Categories count is zero!");

            // Step 3: Get category by ID
            var getCategoryByIdRequest = new RestRequest($"/category/{categoryId}", Method.Get);

            var getCategoryByIdResponse = client.Execute(getCategoryByIdRequest);
            Assert.That(getCategoryByIdResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(getCategoryByIdResponse.Content, Is.Not.Empty,
                "Response content is empty!");
            
            var categoryContent = JObject.Parse(getCategoryByIdResponse.Content);
            Assert.That(categoryContent["_id"].ToString(), Is.EqualTo(categoryId),
                "category ID does not match expected ID!");
            Assert.That(categoryContent["name"].ToString(), Is.EqualTo("Test Category"),
                "Category name does not match the input!");

            // Step 4: Edit the category
            var updateCategoryRequest = new RestRequest($"category/{categoryId}", Method.Put);
            updateCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            updateCategoryRequest.AddJsonBody(new { Name = "Updated Test Category" });

            var updateCategoryResponse = client.Execute(updateCategoryRequest);
            Assert.That(updateCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");

            // Step 5: Verify Edit
            var verifyEditRequest = new RestRequest($"/category/{categoryId}", Method.Get);

            var verifyEditResponse = client.Execute(verifyEditRequest);
            Assert.That(verifyEditResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(verifyEditResponse.Content, Is.Not.Empty,
                "Response content is empty!");

            var updatedCategory = JObject.Parse(verifyEditResponse.Content);
            Assert.That(updatedCategory["name"].ToString(), Is.EqualTo("Updated Test Category"),
                "Updated category does not match the input!");

            // Step 6: Delete the category
            var deleteCategoryRequest = new RestRequest($"/category/{categoryId}", Method.Delete);
            deleteCategoryRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteCategoryResponse = client.Execute(deleteCategoryRequest);
            Assert.That(deleteCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");

            // Step 7: Verify that the deleted category cannot be found
            var verifyDeleteRequest = new RestRequest($"/category/{categoryId}", Method.Get);

            var verifyDeleteResponse = client.Execute(verifyDeleteRequest);
            Assert.That(verifyDeleteResponse.Content, Is.Null.Or.EqualTo("null"),
                "Response content is not null!");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
