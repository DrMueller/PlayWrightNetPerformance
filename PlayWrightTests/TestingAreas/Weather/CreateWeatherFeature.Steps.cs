using FluentAssertions;
using Microsoft.Playwright;
using PlayWrightTests.TestingInfrastructure.Fixtures;

namespace PlayWrightTests.TestingAreas.Weather;

public partial class CreateWeatherFeature(FunctionalTestFixture fixture) : FunctionalTestBase(fixture)
{
    private async Task Given_user_is_on_weather_overview()
    {
        await Page.GotoAsync("/weatheroverview");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    private async Task When_Clicking_on_create_weather_button()
    {
        var btn = Page.GetByTestId("create");
        await btn.ClickAsync();

        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    private async Task When_entering_correct_data()
    {
        var summary = Page.GetByTestId("summary");
        await summary.FillAsync("Summary " + Guid.NewGuid());

        var temparature = Page.GetByTestId("temparature");
        await temparature.FillAsync(25.ToString());
    }

    private async Task When_saving()
    {
        await Page.GetByTestId("save").ClickAsync();
    }

    private Task Then_the_user_is_on_weather_overview()
    {
        return Task.CompletedTask;

        //await Page.WaitForURLAsync("/weatheroverview");
        //Page.Url.Should().EndWith("/weatheroverview");
    }
}