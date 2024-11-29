using Microsoft.Playwright;

namespace PlayWrightTests.TestingInfrastructure.Browsers
{
    internal static class BrowserPlaywrightMap
    {
        private static readonly Lazy<IDictionary<BrowserToTest, Func<IPlaywright, IBrowserType>>> _lazyMap = new(CreateMap);
        internal static IDictionary<BrowserToTest, Func<IPlaywright, IBrowserType>> Map => _lazyMap.Value;

        private static IDictionary<BrowserToTest, Func<IPlaywright, IBrowserType>> CreateMap()
        {
            return new Dictionary<BrowserToTest, Func<IPlaywright, IBrowserType>>
            {
                { BrowserToTest.Chromium, playwright => playwright.Chromium },
                { BrowserToTest.Firefox, playwright => playwright.Firefox },
                { BrowserToTest.Webkit, playwright => playwright.Webkit }
            };
        }
    }
}