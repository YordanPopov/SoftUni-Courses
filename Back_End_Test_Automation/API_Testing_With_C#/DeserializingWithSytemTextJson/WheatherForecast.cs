using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeserializingWithSytemTextJson
{
    public class WheatherForecast
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("temp_c")]
        public int TemperatureC { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }
}
