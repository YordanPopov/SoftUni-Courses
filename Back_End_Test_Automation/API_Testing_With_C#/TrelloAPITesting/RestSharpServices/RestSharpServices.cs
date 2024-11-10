using RestSharp;
using RestSharp.Authenticators;
using RestSharpServices.Models;
using System.Text.Json;

namespace RestSharpServices
{
    public class TrelloApiClient
    {
        private RestClient client;
        private readonly string apiKey;
        private readonly string apiToken;
        Random rnd = new Random();

        public TrelloApiClient(string baseUrl, string key, string token)
        {
            this.apiKey = key;
            this.apiToken = token;

            var options = new RestClientOptions(baseUrl);
            this.client = new RestClient(options);
        }

        private RestRequest AddAuthParameters(RestRequest request)
        {
            request.AddQueryParameter("key", apiKey);
            request.AddQueryParameter("token", apiToken);

            return request;
        }

        public List<Board> GetAllBoards()
        {
            var request = new RestRequest("/1/members/me/boards");

            AddAuthParameters(request);

            var response = client.Execute(request, Method.Get);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<List<Board>>(response.Content);
        }

        public Board CreateBoard(string boardName)
        {
            string randomBoardName = boardName + "-" + rnd.Next(1, 1000);

            var request = new RestRequest("/1/boards/?defaultLists=false");
            request.AddQueryParameter("name", randomBoardName);
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Post);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<Board>(response.Content);
        }

        public bool DeleteBoard(string boardId)
        {
            var request = new RestRequest($"/1/boards/{boardId}");
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Delete);

            return response.IsSuccessful;
        }

        public Board GetSingleBoard(string boardId)
        {
            var request = new RestRequest($"/1/boards/{boardId}");
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Get);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<Board>(response.Content);
        }

        public List CreateToDoList(string boardId)
        {
            string nameList = "To Do";
            var request = new RestRequest($"/1/lists");
            request.AddQueryParameter("name", nameList);
            request.AddQueryParameter("idBoard", boardId);
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Post);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<List>(response.Content);
        }

        public List CreateUniqueList(string boardId)
        {
            string listName = "List-" + rnd.Next(1, 1000);
            var request = new RestRequest($"/1/lists");
            request.AddQueryParameter("name", listName);
            request.AddQueryParameter("idBoard", boardId);
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Post);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<List>(response.Content);
        }

        public List<List> GetAllLists(string boardId)
        {
            var request = new RestRequest($"/1/boards/{boardId}/lists");
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Get);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<List<List>>(response.Content);
        }

        public Card CreateNewCard(string idList)
        {
            string cardName = "Sign-up for Trello";
            var request = new RestRequest("/1/cards");
            request.AddQueryParameter("idList", idList);
            request.AddQueryParameter("name", cardName);
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Post);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<Card>(response.Content);
        }

        public Card MoveCardToUniqueList(string cardId, string idList)
        {
            var request = new RestRequest($"/1/cards/{cardId}");
            request.AddQueryParameter("idList", idList);
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Put);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return JsonSerializer.Deserialize<Card>(response.Content);
        }

        public bool DeleteCard(string cardId)
        {
            var request = new RestRequest($"/1/cards/{cardId}");
            AddAuthParameters(request);

            var response = client.Execute(request, Method.Delete);

            return response.IsSuccessful;
        }
    }
}