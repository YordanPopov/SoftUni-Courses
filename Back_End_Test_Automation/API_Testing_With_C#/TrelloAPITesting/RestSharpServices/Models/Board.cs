using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestSharpServices.Models
{
    public class Board
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name  { get; set; }

        [JsonPropertyName("closed")]
        public bool Closed { get; set; }
    }
}
