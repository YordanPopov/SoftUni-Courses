using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Runtime.Serialization;

namespace ApiTests
{
    [TestFixture]
    public class DestinationTests : IDisposable
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

        [Test, Order(1)]
        public void Test_GetAllDestinations()
        {
            var getAllDestinationsRequest = new RestRequest("/destination", Method.Get);

            var getAllDestinationsResponse = client.Execute(getAllDestinationsRequest);

            Assert.Multiple(() =>
            {
                Assert.That(getAllDestinationsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Status code is not 200 OK!");
                Assert.That(getAllDestinationsResponse.Content, Is.Not.Empty,
                    "Response content is empty");

                var content = JArray.Parse(getAllDestinationsResponse.Content);
                Assert.That(content.Type, Is.EqualTo(JTokenType.Array),
                    "Response content type is not an array!");
                Assert.That(content.Count, Is.GreaterThan(0),
                    "Expected at least one destination in the response!");

                foreach (var destination in content)
                {
                    Assert.That(destination["name"].ToString(), Is.Not.Null.Or.Empty,
                        "Destination name is null or empty!");
                    Assert.That(destination["location"].ToString(), Is.Not.Null.Or.Empty,
                        "Destination location is null or empty!");
                    Assert.That(destination["description"].ToString(), Is.Not.Null.Or.Empty,
                        "Destination description is null or empty!");
                    Assert.That(destination["category"].ToString(), Is.Not.Null.Or.Empty,
                        "Destination category is null or empty!");
                    Assert.That(destination["attractions"].Type, Is.EqualTo(JTokenType.Array),
                        "Destination attractions is not an array!");
                    Assert.That(destination["bestTimeToVisit"].ToString(), Is.Not.Null.Or.Empty,
                        "Destination bestTimeToVisit is null or empty!");
                }
            });
        }

        [Test, Order(2)]
        public void Test_GetDestinationByName()
        {
            var getAllDestinationsRequest = new RestRequest("/destination", Method.Get);

            var getAllDestinationsResponse = client.Execute(getAllDestinationsRequest);

            Assert.Multiple(() =>
            {
                Assert.That(getAllDestinationsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Response status code is not 200 OK!");
                Assert.That(getAllDestinationsResponse.Content, Is.Not.Empty,
                    "Response content is empty");

                var destinations = JArray.Parse(getAllDestinationsResponse.Content);

                var expectedDestination = destinations.FirstOrDefault(d => d["name"].ToString() == "New York City");
                Assert.That(expectedDestination, Is.Not.Null.Or.Empty,
                    "Destination not found!");
                Assert.That(expectedDestination["location"].ToString(), Is.EqualTo("New York, USA"),
                    "Destination does not match expected location!");
                Assert.That(expectedDestination["description"].ToString(), Is.EqualTo("The largest city in the USA, known for its skyscrapers, culture, and entertainment."),
                    "Destination does not match expected description");
            });
        }

        [Test, Order(3)]
        public void Test_AddDestination()
        {
            // Get category ID
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            Assert.That(getAllCategoriesResponse.IsSuccessful, Is.True,
                "Retrieve all categories failed!");

            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            var categoryId = categories.First(c => c["name"].ToString() == "Cities")["_id"].ToString();
            Assert.That(categoryId, Is.Not.Null.Or.Empty,
                "Category ID is null or empty!");

            // Create a new destination
            string[] attractions = new[] { "Attraction1", "Attraction2", "Attraction3" };     
            var addDestinationRequest = new RestRequest("/destination", Method.Post);
            addDestinationRequest.AddHeader("Authorization", $"Bearer {token}");
            addDestinationRequest.AddJsonBody(new
            {
                Name = "Test Destination Name",
                Location = "Test Destination Location",
                Description = "Test Destination Description",
                Attractions = attractions,
                BestTimeToVisit = "Test Best Time To Visit",
                category = categoryId
            });

            var addDestinationResponse = client.Execute(addDestinationRequest);
            Assert.That(addDestinationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(addDestinationResponse.Content, Is.Not.Empty,
                "Response content is empty!");

            // Get destination ID
            var destinationId = JObject.Parse(addDestinationResponse.Content)["_id"].ToString();
            Assert.That(destinationId, Is.Not.Null.Or.Empty,
                "Destination ID is null or empty");

            // Get details about destination
            var getDestinationDetailsRequest = new RestRequest("/destination/{id}", Method.Get);
            getDestinationDetailsRequest.AddUrlSegment("id", destinationId);

            var getDestinationDetailsResponse = client.Execute(getDestinationDetailsRequest);
            Assert.That(getDestinationDetailsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(getDestinationDetailsResponse.Content, Is.Not.Empty,
                "Response content is empty!");

            var destination = JObject.Parse(getDestinationDetailsResponse.Content);

            Assert.That(destination["name"].ToString(), Is.EqualTo("Test Destination Name"),
                "Destination name does not match input");

            Assert.That(destination["location"].ToString(), Is.EqualTo("Test Destination Location"),
                "Destination location does not match input");

            Assert.That(destination["description"].ToString(), Is.EqualTo("Test Destination Description"),
                "Destination description does not match input");

            Assert.That(destination["bestTimeToVisit"].ToString(), Is.EqualTo("Test Best Time To Visit"),
                "Destination BestTimeToVisit does not match input");

            Assert.That(destination["category"], Is.Not.Empty,
                "Destination category property is empty");
            Assert.That(destination["category"]["_id"].ToString(), Is.EqualTo(categoryId),
                "category ID does not match the input");

            Assert.That(destination["attractions"].Type, Is.EqualTo(JTokenType.Array),
                "Attractions is not an array!");
            Assert.That(destination["attractions"].Count, Is.EqualTo(attractions.Length),
                "The array has different number of elements!");
            for (int i = 0; i < attractions.Length; i++)
            {
                Assert.That(destination["attractions"][i].ToString(), Is.EqualTo(attractions[i]),
                    "Attractions element does not match the input!");
            }
        }

        [Test, Order(4)]
        public void Test_UpdateDestination()
        {
            var getAllDestinationsRequest = new RestRequest("/destination", Method.Get);

            var getAllDestinationsResponse = client.Execute(getAllDestinationsRequest);
            Assert.That(getAllDestinationsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(getAllDestinationsResponse.Content, Is.Not.Empty,
                "Response content is empty!");

            var destinations = JArray.Parse(getAllDestinationsResponse.Content);
            var destinationToUpdate = destinations.FirstOrDefault(d => d["name"].ToString() == "Machu Picchu");
            Assert.That(destinationToUpdate, Is.Not.Null,
                "Destination for updating not found!");

            var destinationId = destinationToUpdate["_id"].ToString();

            var updateDestinationRequest = new RestRequest("/destination/{id}", Method.Put);
            updateDestinationRequest.AddHeader("Authorization", $"Bearer {token}");
            updateDestinationRequest.AddUrlSegment("id", destinationId);
            updateDestinationRequest.AddJsonBody(new
            {
                Name = "Updated Name",
                BestTimeToVisit = "Test best time to visit"
            });

            var updateDestinationResponse = client.Execute(updateDestinationRequest);
            Assert.That(updateDestinationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(updateDestinationResponse.Content, Is.Not.Empty, 
                "Response content is empty!");

            var updatedDestination = JObject.Parse(updateDestinationResponse.Content);
            Assert.That(updatedDestination["name"].ToString(), Is.EqualTo("Updated Name"),
                "Destination name does not match the input!");
            Assert.That(updatedDestination["bestTimeToVisit"].ToString(), Is.EqualTo("Test best time to visit"),
                "Destination property BestTimeToVisit does not match the input!");
        }

        [Test, Order(5)]
        public void Test_DeleteDestination()
        {
            var getAllDestinationsRequest = new RestRequest("/destination", Method.Get);

            var getAllDestinationsResponse = client.Execute(getAllDestinationsRequest);
            Assert.That(getAllDestinationsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");
            Assert.That(getAllDestinationsResponse.Content, Is.Not.Empty,
                "Response content is empty!");

            var destinations = JArray.Parse(getAllDestinationsResponse.Content);
            var destinationToDelete = destinations.FirstOrDefault(d => d["name"].ToString() == "Yellowstone National Park");
            Assert.That(destinationToDelete, Is.Not.Null,
                "Destination for deleting not found!");

            var destinationId = destinationToDelete["_id"].ToString();

            var deleteDestinationRequest = new RestRequest("/destination/{id}", Method.Delete);
            deleteDestinationRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteDestinationRequest.AddUrlSegment("id", destinationId);

            var deleteDestinationResponse = client.Execute(deleteDestinationRequest);
            Assert.That(deleteDestinationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Status code is not 200 OK!");

            var verifyDestinationRequest = new RestRequest("/destination/{id}", Method.Get);
            verifyDestinationRequest.AddHeader("Authorization", $"Bearer {token}");
            verifyDestinationRequest.AddUrlSegment("id", destinationId);

            var verifyDestinationResponse = client.Execute(verifyDestinationRequest);
            Assert.That(verifyDestinationResponse.Content, Is.Null.Or.EqualTo("null"),
                "Response content is not null!");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
