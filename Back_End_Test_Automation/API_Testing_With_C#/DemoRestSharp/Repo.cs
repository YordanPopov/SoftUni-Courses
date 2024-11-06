using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp
{
    public class Repo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("html_url")]
        public string Html_url { get; set; }
    }
}
