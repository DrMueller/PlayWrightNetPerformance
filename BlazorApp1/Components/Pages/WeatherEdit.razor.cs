using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages;

public partial class WeatherEdit
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    private WeatherForecast WeatherForecast { get; } = new();

    private void HandleValidSubmit()
    {
        WeatherService.AddForecast(WeatherForecast);
        NavigationManager.NavigateTo("/weatheroverview");
    }
}