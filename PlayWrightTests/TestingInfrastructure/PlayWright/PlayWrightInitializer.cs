namespace PlayWrightTests.TestingInfrastructure.PlayWright
{
    // Taken from https://medium.com/younited-tech-blog/end-to-end-test-a-blazor-app-with-playwright-part-2-3980b573e92a
    public static class PlayWrightInitializer
    {
        public static void Initialize()
        {
            var exitCode = Microsoft.Playwright.Program.Main(["install-deps"]);
            if (exitCode != 0)
            {
                throw new Exception(
                    $"Playwright exited with code {exitCode} on install-deps");
            }

            exitCode = Microsoft.Playwright.Program.Main(["install"]);
            if (exitCode != 0)
            {
                throw new Exception(
                    $"Playwright exited with code {exitCode} on install");
            }
        }
    }
}