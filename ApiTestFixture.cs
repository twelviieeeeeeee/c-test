using NUnit.Framework;

namespace ApiTests
{
    public class ApiTestFixture
    {
        protected ApiClient ApiClient;

        [SetUp]
        public void Setup()
        {
            ApiClient = new ApiClient("https://automationexercise.com");
        }
    }
}