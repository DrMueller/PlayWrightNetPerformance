using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages
{
    public partial class Weather
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private void Create()
        {
            NavigationManager.NavigateTo("/weatheredit");
        }
    }
}
