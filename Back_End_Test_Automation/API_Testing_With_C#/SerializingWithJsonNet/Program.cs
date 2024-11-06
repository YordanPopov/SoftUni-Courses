using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace SerializingWithJsonNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Serializing
            string[] keyWords = { "One apple", "Two apples" };
            Products product = new Products("Apple", 1.50, "This is apple", keyWords);

            var jsonProduct = JsonConvert.SerializeObject(product, Formatting.Indented);
            Console.WriteLine(jsonProduct);

            // Deserializing
            var jsonString = JObject.Parse(File.ReadAllText("D:\\GitHub\\SoftUni-Courses\\Back_End_Test_Automation\\API_Testing_With_C#\\SerializingWithJsonNet\\products.json"));

           // var objProduct = JsonConvert.DeserializeObject<Products>(jsonString);

            // Deserializing anonymous types

            var json = @"{
                          'firstName': 'Yordan',
                           'lastName': 'Popov',
                           'jobTitle': 'Prod manager'
                          }";

            var template = new
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                JobTitle = string.Empty
            };

            var person = JsonConvert.DeserializeAnonymousType(json, template);
        }
    }
}