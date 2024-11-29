using Microsoft.Playwright;
using PlayWrightTests.TestingInfrastructure.Browsers;
using PlayWrightTests.TestingInfrastructure.PlayWright;
using PlayWrightTests.TestingInfrastructure.Startups;
using IBrowserContext = Microsoft.Playwright.IBrowserContext;

namespace PlayWrightTests.TestingInfrastructure.Fixtures
{
    public sealed class FunctionalTestFixture : IDisposable, IAsyncDisposable
    {
        private readonly IDictionary<BrowserToTest, IBrowser> _browserCache;

        public FunctionalTestFixture()
        {
            _browserCache = new Dictionary<BrowserToTest, IBrowser>();
            PlayWrightInitializer.Initialize();
        }

        // Singleton per xunit collection
        internal FunctionalTestAppFactory AppFactory { get; } = new();

        public async Task<IBrowserContext> AssuereBrowserContextAsync(BrowserToTest browserToTest, string baseAddress)
        {
            if (!_browserCache.TryGetValue(browserToTest, out var existingBrowser))
            {
                var playwrightInstance = await Playwright.CreateAsync();
                var browserType = BrowserPlaywrightMap.Map[browserToTest](playwrightInstance);
                existingBrowser = await browserType.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = true
                });

                _browserCache.Add(browserToTest, existingBrowser);
            }

            var context = await existingBrowser.NewContextAsync(new BrowserNewContextOptions
            {
                BaseURL = baseAddress,
                IgnoreHTTPSErrors = true,
                StrictSelectors = true,
                BypassCSP = false
            });

            context.SetDefaultTimeout(5000);

            if (browserToTest == BrowserToTest.Webkit)
            {
                await context.Tracing.StartAsync(new TracingStartOptions
                {
                    Screenshots = true,
                    Snapshots = true,
                    Sources = true
                });
            }

            return context;
        }

        public void Dispose()
        {
            AppFactory.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await AppFactory.DisposeAsync();
        }
    }
}