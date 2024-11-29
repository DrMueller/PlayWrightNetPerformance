//using System.Diagnostics;
//using LightBDD.XUnit2;
//using PlayWrightTests.TestingInfrastructure.Browsers;

//namespace PlayWrightTests.TestingAreas.Weather;

//public partial class LoadWeatherFeature
//{
//    [Scenario]
//    [Browsers]
//    public async Task LoadingWeather_LoadsWeather(BrowserToTest browser)
//    {
//        var runCount = 50;

//        var stopwatch = new Stopwatch();

//        for (var i = 0; i < runCount; i++)
//        {
//            stopwatch.Start();
//            await RunScenarioAsync(
//                browser,
//                _ => When_the_weather_page_is_loaded(),
//                _ => Then_the_weather_data_is_loaded());
//        }
//    }
//}