using System.Linq.Expressions;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using Microsoft.Playwright;
using PlayWrightTests.TestingInfrastructure.Browsers;
using Xunit;

namespace PlayWrightTests.TestingInfrastructure.Fixtures
{
    [Collection(FunctionalTestsCollectionFixture.CollectionName)]
    public abstract class FunctionalTestBase : FeatureFixture
    {
        protected IBrowserContext BrowserContext = null!;

        private readonly FunctionalTestFixture _fixture;

        // This happens once per test
        protected FunctionalTestBase(FunctionalTestFixture fixture)
        {
    
            _fixture = fixture;
        }

        protected IServiceProvider ServiceProvider => _fixture.AppFactory.Services;

        protected IPage Page { get; set; } = null!;

        protected virtual Task AfterInitializedAsync()
        {
            return Task.CompletedTask;
        }

        protected async Task ResizePageAsync(int width, int height)
        {
            await Page.SetViewportSizeAsync(width, height);
        }

        protected async Task RunScenarioAsync(
            BrowserToTest browser,
            params Expression<Func<NoContext, Task>>[] steps)
        {
            await InitializeBrowserAsync(browser);
            await Runner.RunScenarioAsync(steps);
        }

        private async Task InitializeBrowserAsync(BrowserToTest browser)
        {
            BrowserContext = await _fixture.AssuereBrowserContextAsync(browser, _fixture.AppFactory.ServerAddress);

            Page = await BrowserContext.NewPageAsync();
            await AfterInitializedAsync();
        }
    }
}