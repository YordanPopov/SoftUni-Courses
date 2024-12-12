using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace ApiTests
{
    [TestFixture]
    public class RecipeTests : IDisposable
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
        public void Test_GetAllRecipes()
        {
            var getAllRecipesRequest = new RestRequest("/recipe", Method.Get);

            var getAllRecipesResponse = client.Execute(getAllRecipesRequest);
            Assert.That(getAllRecipesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting all recipes is failed");
            Assert.That(getAllRecipesResponse.Content, Is.Not.Empty,
                "Getting all recipes content body is empty");

            var recipes = JArray.Parse(getAllRecipesResponse.Content);
            Assert.That(recipes.Type, Is.EqualTo(JTokenType.Array),
                "Getting all recipe content is not an array");
            Assert.That(recipes.Count, Is.GreaterThan(0),
                "Expected at least one recipe");

            foreach (var recipe in recipes)
            {
                Assert.That(recipe["title"]?.ToString(), Is.Not.Null.Or.Empty,
                    "Recipe title is null or empty");
                Assert.That(recipe["cookingTime"]?.ToString(), Is.Not.Null.Or.Empty,
                    "Recipe cookingTime is null or empty");
                Assert.That(recipe["servings"]?.ToString(), Is.Not.Null.Or.Empty,
                    "Recipe servings is null or empty");
                Assert.That(recipe["category"]?.ToString(), Is.Not.Null.Or.Empty,
                    "Recipe category is null or empty");
                Assert.That(recipe["ingredients"]?.Type, Is.EqualTo(JTokenType.Array),
                    "Recipe ingredients type is not an array");
                Assert.That(recipe["instructions"]?.Type, Is.EqualTo(JTokenType.Array),
                    "Recipe instructions type is not an array");
            }
        }

        [Test]
        public void Test_GetRecipeByTitle()
        {
            RestRequest getAllRecipesRequest = new RestRequest("/recipe", Method.Get);

            RestResponse getAllRecipesResponse = client.Execute(getAllRecipesRequest);
            Assert.That(getAllRecipesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting all recipes is failed");
            Assert.That(getAllRecipesResponse.Content, Is.Not.Empty,
                "Getting all recipes content body is empty");

            var recipes = JArray.Parse(getAllRecipesResponse.Content);
            var expectedRecipe = recipes.FirstOrDefault(r => r["title"]?.ToString() == "Chocolate Chip Cookies");
            Assert.That(expectedRecipe, Is.Not.Null.Or.Empty,
                "There no have recipe with name 'Chocolate Chip Cookies'");

            Assert.That(expectedRecipe["cookingTime"].Value<int>, Is.EqualTo(25));
            Assert.That(expectedRecipe["servings"].Value<int>, Is.EqualTo(24));
            Assert.That(expectedRecipe["ingredients"].Count, Is.EqualTo(9));
            Assert.That(expectedRecipe["instructions"].Count, Is.EqualTo(7));
        }

        [Test]
        public void Test_AddRecipe()
        {
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting all categories failed");
            Assert.That(getAllCategoriesResponse.Content, Is.Not.Empty,
                "Getting all categories content body is empty");

            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            Assert.That(categories.Count, Is.GreaterThan(0),
                "There no existing categories");

            var categoryId = categories.First()["_id"]?.ToString();
            Assert.That(categoryId, Is.Not.Null.Or.Empty,
                "Category ID is null or empty");

            // Create a new recipe
            var ingredients = new []
            {
                new { name = "ingredient1", quantity = 1 },
                new { name = "ingredient2", quantity = 2 }
            };

            var instructions = new[]
            {
                new { step = "Test step1" },
                new { step = "Test step2" }
            };

            var createRecipeRequest = new RestRequest("/recipe", Method.Post);
            createRecipeRequest.AddHeader("Authorization", $"Bearer {token}");
            createRecipeRequest.AddJsonBody(new {
                Title = "Test Recipe",
                Description = "Test Description",
                Ingredients = ingredients,
                Instructions = instructions,
                CookingTime = 10,
                Servings = 10,
                Category = categoryId
            });

            var createRecipeResponse = client.Execute(createRecipeRequest);
            Assert.That(createRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Creating recipe is failed");
            Assert.That(createRecipeResponse.Content, Is.Not.Empty,
                "Creating recipe response content body is empty");

            var recipeId = JObject.Parse(createRecipeResponse.Content)["_id"]?.ToString();
            Assert.That(recipeId, Is.Not.Null.Or.Empty,
                "Recipe ID is null or empty");

            // Retrieve details for recipe
            var getRecipeByIdRequest = new RestRequest($"/recipe/{recipeId}", Method.Get);

            var getRecipeByIdResponse = client.Execute(getRecipeByIdRequest);
            Assert.That(getRecipeByIdResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting recipe by id failed");
            Assert.That(getRecipeByIdResponse.Content, Is.Not.Null.Or.Empty,
                "Getting recipe by id response content body is null or empty");

            var recipe = JObject.Parse(getRecipeByIdResponse.Content);
            Assert.That(recipe["title"]?.ToString(), Is.EqualTo("Test Recipe"),
                "Recipe title does not match the input");

            Assert.That(recipe["cookingTime"].Value<int>, Is.EqualTo(10),
                "Recipe cookingTime does not match the input");

            Assert.That(recipe["servings"].Value<int>, Is.EqualTo(10),
                "Recipe servings does not match the input");

            Assert.That(recipe["category"]?.ToString(), Is.Not.Empty,
                "Recipe category is empty");

            Assert.That(recipe["category"]["_id"]?.ToString(), Is.EqualTo(categoryId),
                "Recipe category ID does not match expected ID");

            Assert.That(recipe["ingredients"]?.Type, Is.EqualTo(JTokenType.Array),
                "Recipe ingredients type is not an array");

            Assert.That(recipe["ingredients"].Count, Is.EqualTo(ingredients.Length),
                "Recipe ingredients count does not match the input count");

            Assert.That(recipe["ingredients"][0]["name"].ToString(), Is.EqualTo("ingredient1"),
                "Recipe ingredients element does not match the input");

            Assert.That(recipe["ingredients"][1]["name"].ToString(), Is.EqualTo("ingredient2"),
                "Recipe ingredients element does not match the input");

            Assert.That(recipe["ingredients"][0]["quantity"].Value<int>, Is.EqualTo(1),
                "Recipe ingredients element does not match the input");

            Assert.That(recipe["ingredients"][1]["quantity"].Value<int>, Is.EqualTo(2),
                "Recipe ingredients element does not match the input");

            Assert.That(recipe["instructions"].Type, Is.EqualTo(JTokenType.Array),
                "Recipe instructions type is not an array");

            Assert.That(recipe["instructions"].Count, Is.EqualTo(instructions.Length),
                "Recipe instructions count does not match the input count");

            Assert.That(recipe["instructions"][0]["step"].ToString(), Is.EqualTo("Test step1"),
                "Recipe instructions element does not match the input");

            Assert.That(recipe["instructions"][1]["step"].ToString(), Is.EqualTo("Test step2"),
                "Recipe instructions element does not match the input");
        }

        [Test]
        public void Test_UpdateRecipe()
        {
            RestRequest getAllRecipesRequest = new RestRequest("/recipe", Method.Get);

            RestResponse getAllRecipesResponse = client.Execute(getAllRecipesRequest);
            Assert.That(getAllRecipesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting all recipes is failed");
            Assert.That(getAllRecipesResponse.Content, Is.Not.Empty,
                "Getting all recipes content body is empty");

            var recipes = JArray.Parse(getAllRecipesResponse.Content);
            var recipeToUpdate = recipes.FirstOrDefault(r => r["title"]?.ToString() == "Spaghetti Carbonara");
            Assert.That(recipeToUpdate, Is.Not.Null,
                "Recipe to update not exist");

            var recipeId = recipeToUpdate["_id"]?.ToString();
            Assert.That(recipeId, Is.Not.Null.Or.Empty,
                "Recipe ID is null or empty");

            var updateRecipeRequest = new RestRequest($"/recipe/{recipeId}", Method.Put);
            updateRecipeRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRecipeRequest.AddJsonBody(new
            {
                Title = "Spaghetti Bolognese",
                Servings = 0
            });

            var updateRecipeResponse = client.Execute(updateRecipeRequest);
            Assert.That(updateRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Updating recipe failed");
            Assert.That(updateRecipeResponse.Content, Is.Not.Empty,
                "Updating recipe response content is empty");

            var updatedRecipe = JObject.Parse(updateRecipeResponse.Content);
            Assert.That(updatedRecipe["title"]?.ToString(), Is.EqualTo("Spaghetti Bolognese"),
                "Recipe title does not match the input");
            Assert.That(updatedRecipe["servings"].Value<int>, Is.EqualTo(0),
                "Recipe servings does not match the input");
        }

        [Test]
        public void Test_DeleteRecipe()
        {
            RestRequest getAllRecipesRequest = new RestRequest("/recipe", Method.Get);

            RestResponse getAllRecipesResponse = client.Execute(getAllRecipesRequest);
            Assert.That(getAllRecipesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Getting all recipes is failed");
            Assert.That(getAllRecipesResponse.Content, Is.Not.Empty,
                "Getting all recipes content body is empty");

            var recipes = JArray.Parse(getAllRecipesResponse.Content);
            var recipeToDelete = recipes.FirstOrDefault(r => r["title"]?.ToString() == "Chicken Curry");
            Assert.That(recipeToDelete, Is.Not.Null,
                "There no have recipe with title 'Chicken Curry'");

            var recipeId = recipeToDelete["_id"]?.ToString();
            Assert.That(recipeId, Is.Not.Null.Or.Empty,
                "Recipe ID is null or empty");

            var deleteRecipeRequest = new RestRequest($"/recipe/{recipeId}", Method.Delete);
            deleteRecipeRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteRecipeResponse = client.Execute(deleteRecipeRequest);
            Assert.That(deleteRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Deleting recipe is failed");

            var verifyDeleteRequest = new RestRequest($"/recipe/{recipeId}", Method.Get);

            var verifyDeleteResponse = client.Execute(verifyDeleteRequest);
            Assert.That(verifyDeleteResponse.Content, Is.Null.Or.EqualTo("null"),
                "Verifying delete response is not null");
        }

        [Test]
        public void Test_RecipeLifecycle_RecipeBook()
        {
            // Create new category
            var createCategoryRequest = new RestRequest("/category", Method.Post);
            createCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            createCategoryRequest.AddJsonBody(new
            {
                Name = "Gluten-Free"
            });

            var createCategoryResponse = client.Execute(createCategoryRequest);
            Assert.That(createCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Creating new category is failed");
            Assert.That(createCategoryResponse.Content, Is.Not.Null.Or.Empty,
                "Creating category response is null or empty");

            var createCategoryResponseContent = JObject.Parse(createCategoryResponse.Content);
            Assert.That(createCategoryResponseContent["_id"]?.ToString(), Is.Not.Null.Or.Empty,
                "Category ID is null or empty");
            Assert.That(createCategoryResponseContent["name"]?.ToString(), Is.EqualTo("Gluten-Free"),
                "Category name does not match the input");
            Assert.That(createCategoryResponseContent.ContainsKey("createdAt"), Is.True,
                "Category createdAt property does not exist");
            Assert.That(createCategoryResponseContent.ContainsKey("updatedAt"), Is.True,
                "Category updatedAt property does not exist");
            Assert.That(createCategoryResponseContent["createdAt"]?.ToString(), Is.EqualTo(createCategoryResponseContent["updatedAt"]?.ToString()),
                "CreateAt and updatedAt are not equal");

            string categoryId = createCategoryResponseContent["_id"]?.ToString();

            // Create new recipe
            var payload = new
            {
                Name = "Spaghetti ala bala",
                Description = "Spaghetti ala bala description",
                Ingredients = new[]
                {
                    new { name = "Spaghetti", quantity = "200g" }
                },
                Instructions = new[]
                {
                    new { step = "Cook the according to package instructions." }
                },
                CookingTime = 20,
                Servings = 2,
                Category = categoryId
            };

            var createNewRecipeRequest = new RestRequest("/recipe", Method.Post);
            createNewRecipeRequest.AddHeader("Authorization", $"Bearer {token}");
            createNewRecipeRequest.AddJsonBody(payload);

            var createNewRecipeResponse = client.Execute(createNewRecipeRequest);
            Assert.That(createNewRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Creating a new recipe is failed");
            Assert.That(createNewRecipeResponse.Content, Is.Not.Null.Or.Not.Empty,
                "Creating recipe response is null or empty");

            var createRecipeResponseContent = JObject.Parse(createNewRecipeResponse.Content);
            Assert.Multiple(() =>
            {
                var content = createCategoryResponseContent;
                Assert.IsNotEmpty(content["name"]?.ToString(),
                    "Reicpe name is empty");
                Assert.That(content["name"]?.ToString(), Is.EqualTo(payload.Name),
                    "Recipe name does not match the input");
                Assert.IsNotEmpty(content["description"]?.ToString(),
                    "Recipe description is empty");
                Assert.That(content["decription"]?.ToString(), Is.EqualTo(payload.Description),
                    "Recipe description does not match the input");
                Assert.That(content["ingredients"].Type, Is.EqualTo(JTokenType.Array),
                    "Recipe ingredients property is not an array");
            });
        }
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
