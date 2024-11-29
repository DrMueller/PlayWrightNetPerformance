using System.Reflection;
using Xunit.Sdk;

namespace PlayWrightTests.TestingInfrastructure.Browsers
{
    public class BrowsersAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {

            var browsers = new List<object[]>
            {
                new object[] { BrowserToTest.Chromium },
                //new object[] { BrowserToTest.Firefox },
                new object[] { BrowserToTest.Webkit }
            };

            return browsers;
        }
    }
}