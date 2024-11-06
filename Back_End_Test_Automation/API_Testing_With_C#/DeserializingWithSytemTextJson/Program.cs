using System.Text.Json;

namespace DeserializingWithSytemTextJson
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            string jsonString = File.ReadAllText("D:\\GitHub\\SoftUni-Courses\\Back_End_Test_Automation\\API_Testing_With_C#\\DeserializingWithSytemTextJson\\Data\\WeathersForecasts.json");

            List<WheatherForecast> forecasts = JsonSerializer.Deserialize<List<WheatherForecast>>(jsonString);

            foreach (WheatherForecast forecast in forecasts)
            {
                string txt = "";
                txt += $"Date:{forecast.Date}\nTemperature:{forecast.TemperatureC}\nSummary:{forecast.Summary}";
                Console.WriteLine(txt);
            }
        }
    }
}