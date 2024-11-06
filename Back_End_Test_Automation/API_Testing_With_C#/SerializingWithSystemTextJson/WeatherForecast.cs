using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SerializingWithSystemTextJson
{
    public class WeatherForecast
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("temp_c")]
        public int TemperatureC { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        public WeatherForecast(DateTime date, int temp, string summary)
        {
            this.Date = date;
            this.TemperatureC = temp;
            this.Summary = summary;
        }
    }
}
