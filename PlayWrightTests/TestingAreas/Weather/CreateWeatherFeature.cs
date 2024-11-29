using System.Diagnostics;
using LightBDD.XUnit2;
using PlayWrightTests.TestingInfrastructure.Browsers;

namespace PlayWrightTests.TestingAreas.Weather;

public partial class CreateWeatherFeature
{
    [Scenario]
    [Browsers]
    public async Task Create_Individual(BrowserToTest browser)
    {
        var runCount = 50;
        var stopwatch = new Stopwatch();

        for (var i = 0; i < runCount; i++)
        {
            stopwatch.Start();
            await RunScenarioAsync(
                browser,
                _ => Given_user_is_on_weather_overview(),
                _ => When_Clicking_on_create_weather_button(),
                _ => When_entering_correct_data(),
                _ => When_saving(),
                _ => Then_the_user_is_on_weather_overview());
        }
    }
}