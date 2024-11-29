using BlazorApp1;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PlayWrightTests.TestingInfrastructure.Startups
{
    public sealed class FunctionalTestAppFactory : WebApplicationFactory<Program>
    {
        private const string LocalhostBaseAddress = "https://localhost";
        private IHost? _host;

        public FunctionalTestAppFactory()
        {
            EnsureServer();
            ClientOptions.BaseAddress = new Uri(LocalhostBaseAddress);
        }

        public string ServerAddress { get; private set; } = null!;

        public override IServiceProvider Services => _host!.Services;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            // Setting port to 0 means that Kestrel will pick any free a port.
            builder.UseUrls("https://127.0.0.1:0");
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var testHost = builder.Build();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", true)
                .Build();

            builder.ConfigureWebHost(g =>
            {
                g.UseKestrel()
                    .UseSetting(WebHostDefaults.ApplicationKey, "BlazorApp1") // Required to generate the correct bundled css and to locate the javascripts per component
                    .UseConfiguration(config)
                    .UseContentRoot(GetPresentationDirectoryRootPath())
                    .UseEnvironment("Development"); // Important, otherwise static files (aka ManifestStaticWebAssetFileProvider) arent served
            });

            _host = builder.Build();
            _host.Start();

            var server = _host.Services.GetRequiredService<IServer>();
            ServerAddress = server.Features.Get<IServerAddressesFeature>()!.Addresses.Last();

            testHost.Start();
            return testHost;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _host?.Dispose();
            }
        }

        private static string GetPresentationDirectoryRootPath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dirInfo = new DirectoryInfo(currentDirectory);

            while (dirInfo!.Name != "PlayWrightNetPerformance")
            {
                dirInfo = dirInfo.Parent;
            }

            return Path.Combine(dirInfo.FullName, "BlazorApp1");
        }

        private void EnsureServer()
        {
            if (_host is null)
            {
                using var _ = CreateDefaultClient();
            }
        }
    }
}