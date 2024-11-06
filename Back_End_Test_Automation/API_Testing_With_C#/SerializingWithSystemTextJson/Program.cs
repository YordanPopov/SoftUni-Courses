using System.Text.Json;

namespace SerializingWithSystemTextJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherForecast forecast = new WeatherForecast(DateTime.Now, 30, "Hot summer day!");

            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string weatherInfo = JsonSerializer.Serialize(forecast, option);
            Console.WriteLine(weatherInfo);
        }
    }
}