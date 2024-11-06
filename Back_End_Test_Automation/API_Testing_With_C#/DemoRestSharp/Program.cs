using Newtonsoft.Json;
using RestSharp;

namespace DemoRestSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.github.com/");

            var request = new RestRequest("/users/softuni/repos", Method.Get);

            var response = client.Execute(request);

            //Console.WriteLine(response.Content);

            // Using URL Segment Parameters
            var client2 = new RestClient("https://api.github.com/");

            var request2 = new RestRequest("/repos/{user}/{repo}/issues/{id}", Method.Get);

            request2.AddUrlSegment("user", "testnakov");
            request2.AddUrlSegment("repo", "test-nakov-repo");
            request2.AddUrlSegment("id", 1);

            var response2 = client2.Execute(request2);

            //Console.WriteLine(response2.StatusCode);
            //Console.WriteLine(response2.Content);

            // Deserializing JSON Response
            var repos = JsonConvert.DeserializeObject<List<Repo>>(response.Content);

            foreach (var repo in repos)
            {
                string txt = "";
                txt += $"{repo.Id} -> {repo.FullName} -> {repo.Html_url}";
                Console.WriteLine(txt);
            }
        }
    }
}