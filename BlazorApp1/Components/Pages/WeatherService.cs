 namespace BlazorApp1.Components.Pages
{
    public static class WeatherService
    {
        public static void AddForecast(WeatherForecast forecast)
        {
            ForecastItems.Add(forecast);
        }

        private static List<WeatherForecast> ForecastItems { get; set; } = new List<WeatherForecast>();

        public static IReadOnlyCollection<WeatherForecast> WeatherForecasts => ForecastItems.Take(1).ToList();

    }
}
