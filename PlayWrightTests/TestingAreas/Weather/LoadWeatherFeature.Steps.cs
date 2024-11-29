//using FluentAssertions;
//using Microsoft.Playwright;
//using PlayWrightTests.TestingInfrastructure.Fixtures;

//namespace PlayWrightTests.TestingAreas.Weather;

//public partial class LoadWeatherFeature(FunctionalTestFixture fixture) : FunctionalTestBase(fixture)
//{
//    private async Task When_the_weather_page_is_loaded()
//    {
//        await Page.GotoAsync("/weather");
//        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
//    }

//    private async Task Then_the_weather_data_is_loaded()
//    {
//        var weatherElement = Page.GetByTestId("weather-list");
//        var tableBody = weatherElement.Locator("tbody");
//        var tableRows = tableBody.Locator("tr");
//        var secondRow = tableRows.Nth(0);
//        await secondRow.WaitForAsync();

//        var rowCount = await tableRows.CountAsync();
//        rowCount.Should().BeGreaterThan(0);
//    }
//}