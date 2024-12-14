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
            Assert.Multiple(() =>
            {
                Assert.That(createCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "The category creation response did not return a 200 OK status.");
                Assert.That(createCategoryResponse.Content, Is.Not.Null.Or.Empty,
                    "The category creation response content is null or empty.");

                var content = JObject.Parse(createCategoryResponse.Content);
                Assert.That(content["_id"]?.ToString(), Is.Not.Null.Or.Empty,
                    "The category creation response does not contain a valid '_id'.");
                Assert.That(content["name"]?.ToString(), Is.EqualTo("Gluten-Free"),
                    "he category name in the response does not match the expected value.");
                Assert.That(content.ContainsKey("createdAt"), Is.True,
                    "The category creation response does not contain the 'createdAt' field.");
                Assert.That(content.ContainsKey("updatedAt"), Is.True,
                    "The category creation response does not contain the 'updatedAt' field.");
                Assert.That(content["createdAt"]?.ToString(),
                    Is.EqualTo(content["updatedAt"]?.ToString()),
                    "'createdAt' and 'updatedAt' timestamps do not match in the category creation response.");
            });

            var categoryId = JObject.Parse(createCategoryResponse.Content)["_id"]?.ToString();

            // Create new recipe
            var payload = new
            {
                Title = "Spaghetti ala bala",
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
          
            Assert.Multiple(() =>
            {
                Assert.That(createNewRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "The recipe creation response did not return a 200 OK status.");
                Assert.That(createNewRecipeResponse.Content, Is.Not.Null.Or.Not.Empty,
                    "The recipe creation response content is null or empty.");

                var content = JObject.Parse(createNewRecipeResponse.Content);
                Assert.IsNotEmpty(content["title"]?.ToString(),
                    "The recipe title in the response is empty.");
                Assert.That(content["title"]?.ToString(), Is.EqualTo("Spaghetti ala bala"),
                    "The recipe title in the response does not match the expected value.");
                Assert.IsNotEmpty(content["description"]?.ToString(),
                    "The recipe description in the response is empty.");
                Assert.That(content["description"]?.ToString(), Is.EqualTo("Spaghetti ala bala description"),
                    "The recipe description in the response does not match the expected value.");
                Assert.That(content["ingredients"]?.Type, Is.EqualTo(JTokenType.Array),
                    "The 'ingredients' field is not an array.");
                Assert.That(content["ingredients"]?.Count(), Is.GreaterThan(0),
                    "The 'ingredients' array is empty.");
                Assert.That(content["ingredients"][0]["name"].ToString(), Is.EqualTo("Spaghetti"),
                    "The first ingredient name does not match the expected value.");
                Assert.That(content["ingredients"][0]["quantity"].ToString(), Is.EqualTo("200g"),
                    "The first ingredient quantity does not match the expected value.");
                Assert.That(content["instructions"].Type, Is.EqualTo(JTokenType.Array),
                    "The 'instructions' field is not an array.");
                Assert.That(content["instructions"].Count(), Is.GreaterThan(0),
                    "The 'instructions' array is empty.");
                Assert.That(content["instructions"][0]["step"].ToString(),
                    Is.EqualTo("Cook the according to package instructions."),
                    "The first instruction step does not match the expected value.");
                Assert.That(content["cookingTime"]?.ToString(), Is.Not.Null.Or.Empty,
                    "The 'cookingTime' field is null or empty.");
                Assert.That(content["cookingTime"].Value<int>, Is.EqualTo(20),
                    "The 'cookingTime' value does not match the expected value.");
                Assert.That(content["servings"]?.ToString(), Is.Not.Null.Or.Empty,
                    "The 'servings' field is null or empty.");
                Assert.That(content["servings"].Value<int>, Is.EqualTo(2),
                    "The 'servings' value does not match the expected value.");
                Assert.That(content["category"]["_id"]?.ToString(), Is.Not.Null.Or.Empty,
                    "The category '_id' in the recipe response is null or empty.");
                Assert.That(content["category"]["_id"]?.ToString(), Is.EqualTo(categoryId),
                    "The category '_id' in the recipe response does not match the expected value.");
            });

            // Update the recipe
            var getAllRecipesRequest = new RestRequest("/recipe"); // Method.GET by Default :)

            var getAllRecipeResponse = client.Execute(getAllRecipesRequest);
            Assert.That(getAllRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "The request to fetch all recipes did not return a 200 OK status.");
            Assert.That(getAllRecipeResponse.Content, Is.Not.Null.Or.Empty,
                "The response content for fetching all recipes is null or empty.");

            var recipes = JArray.Parse(getAllRecipeResponse.Content);
            Assert.That(recipes.Type, Is.EqualTo(JTokenType.Array),
                "The 'recipes' response is not an array.");
            Assert.That(recipes.Count, Is.GreaterThan(0),
                "The 'recipes' array is empty.");

            var recipeToUpdate = recipes.FirstOrDefault(r => r["title"].ToString() == "Spaghetti ala bala");
            Assert.That(recipeToUpdate, Is.Not.Null.Or.Empty,
                "No recipe with the title 'Spaghetti ala bala' was found.");

            string recipeId = recipeToUpdate["_id"].ToString();
            Assert.That(recipeId, Is.Not.Null.Or.Empty);

            var updateRecipeRequest = new RestRequest("/recipe/{id}", Method.Put);
            updateRecipeRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRecipeRequest.AddUrlSegment("id", recipeId);
            updateRecipeRequest.AddJsonBody(new
            {
                Title = "Spaghetti",
                Description = "Spaghetti"
            });

            var updateRecipeResponse = client.Execute(updateRecipeRequest);

            Assert.Multiple(() =>
            {
                Assert.That(updateRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "The recipe update response did not return a 200 OK status.");
                Assert.That(updateRecipeResponse.Content, Is.Not.Null.Or.Empty,
                    "The recipe update response content is null or empty.");

                var updatedRecipe = JObject.Parse(updateRecipeResponse.Content);
                Assert.That(updatedRecipe["title"].ToString(), Is.EqualTo("Spaghetti"),
                    "The updated recipe title does not match the expected value.");
                Assert.That(updatedRecipe["description"].ToString(), Is.EqualTo("Spaghetti"),
                    "The updated recipe description does not match the expected value."); 
                Assert.That(updatedRecipe["cookingTime"].Value<int>, Is.EqualTo(20),
                    "The updated recipe cooking time does not match the expected value.");
            });

            // Delete recipe
            var deleteRecipeRequest = new RestRequest("/recipe/{id}", Method.Delete);
            deleteRecipeRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRecipeRequest.AddUrlSegment("id", recipeId);
            
            var deleteRecipeResponse = client.Execute(deleteRecipeRequest);

            Assert.Multiple(() =>
            {
                Assert.That(deleteRecipeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "The recipe delete response did not return a 200 OK status.");
                Assert.That(deleteRecipeResponse.Content, Is.Not.Null.Or.Empty,
                    "The recipe delete response content is null or empty");
            });

            // Delete category
            var deleteCategoryRequest = new RestRequest("/category/{id}", Method.Delete);
            deleteCategoryRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteCategoryRequest.AddUrlSegment("id", categoryId);

            var deleteCategoryResponse = client.Execute(deleteCategoryRequest);

            Assert.Multiple(() =>
            {
                Assert.That(deleteCategoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "The category delete response did not return a 200 OK status.");
                Assert.That(deleteCategoryResponse.Content, Is.Not.Null.Or.Empty,
                    "The category delete response content is null or empty");
            });
        }
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
