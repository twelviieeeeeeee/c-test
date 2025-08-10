using ApiTests;
using NUnit.Framework;

namespace ApiTests
{
    [TestFixture]
    public class ProductApiTests : ApiTestFixture
    {
        [Test]
        public void GetAllProducts_ShouldReturnProductsList()
        {
            var json = ApiClient.GetAllProducts();

            Assert.IsTrue(json.ContainsKey("products"), "Response JSON does not contain 'products'");
            Assert.IsTrue(json["products"].HasValues, "Products list is empty");
        }
    }
}

public class ProductPostTests : ApiTestFixture
{
    private PostClient _postClient;

    [SetUp]
    public void Setup()
    {
        base.Setup();
        _postClient = new PostClient("https://automationexercise.com");
    }

    [Test]
    public async Task PostToAllProducts_ShouldReturnResponseCode405InBody()
    {
        var body = new { };

        var json = await _postClient.PostToAllProductsAsync(body);
        
        Assert.That(json.ContainsKey("responseCode"), Is.True, "Response JSON does not contain 'responseCode'");
        Assert.That((int)json["responseCode"], Is.EqualTo(405), "Response code is not 405");
        Assert.That(json.ContainsKey("message"), Is.True, "Response JSON does not contain 'message'");
        Assert.That(json["message"].ToString(), Does.Contain("not supported").IgnoreCase);
    }
}

