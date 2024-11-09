using RestSharpServices;

namespace ZippopotamApiTest
{
    public class Tests
    {
        private ZippopotamApiClient client;

        [SetUp]
        public void Setup()
        {
            this.client = new ZippopotamApiClient("https://api.zippopotam.us");
        }

        [TestCase("BG", "1000", "София / Sofija")]
        [TestCase("BG", "5000", "Велико Търново / Veliko Turnovo")]
        [TestCase("BG", "7400", "Исперих / Isperikh")]
        public void Test_GetLocationByCountryAndPostCode(string countryCode, string postCode, string expectedPlace)
        {
            var location = client.GetLocationByCountryAndPostCode(countryCode, postCode);

            //Assert.That(location, Is.Not.Null);
            //StringAssert.Contains(expectedPlace, location.Places[0].PlaceName);
            Assert.That(location.Places[0].PlaceName, Is.EqualTo(expectedPlace));
        }
    }
}