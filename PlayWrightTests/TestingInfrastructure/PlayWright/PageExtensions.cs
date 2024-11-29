using Microsoft.Playwright;

namespace PlayWrightTests.TestingInfrastructure.PlayWright
{
    internal static class PageExtensions
    {
        // Just a helper for debugging purpose
        internal static async Task TakeScreenshotAsync(this IPage page, string? name = null)
        {
            name ??= "PlayWrightScreenshot";
            name += ".png";

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = $@"C:\Temp\{name}"
            });
        }
    }
}