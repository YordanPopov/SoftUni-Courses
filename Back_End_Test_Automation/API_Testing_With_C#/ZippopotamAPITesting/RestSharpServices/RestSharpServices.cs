using RestSharp;
using RestSharpServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestSharpServices
{
    public class ZippopotamApiClient
    {
        private RestClient client;
        public ZippopotamApiClient(string baseUrl)
        {
            this.client = new RestClient(baseUrl);
        }

        public Location GetLocationByCountryAndPostCode(string countryCode, string postCode)
        {
            var request = new RestRequest($"/{countryCode}/{postCode}");

            var response = client.Execute(request, Method.Get);

            return response.Content != null ? JsonSerializer.Deserialize<Location>(response.Content) : null;
        }
    }
}
