using Xunit;

namespace PlayWrightTests.TestingInfrastructure.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class FunctionalTestsCollectionFixture : ICollectionFixture<FunctionalTestFixture>
    {
        internal const string CollectionName = "FunctionalTests";
    }
}