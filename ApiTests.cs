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

public class GetAllTests : ApiTestFixture
{
    private GetAllClient _getAllClient;

    [SetUp]
    public void Setup()
    {
        base.Setup();
        _getAllClient = new GetAllClient("https://automationexercise.com");
    }

    [Test]
    public async Task GetAllBrandsList_ShoulReturnResponseCode200InBody()
    {
        var body = new { };

        var json = await _getAllClient.GetAllBrandsListAsync(body);

        Assert.That(json.ContainsKey("responseCode"), Is.True, "Response JSON does not contain 'responseCode'");
        Assert.That((int)json["responseCode"], Is.EqualTo(200), "Response code is not 200");
    }
}

public class PutToTests : ApiTestFixture
{
    private PutClient _putClient;

    [SetUp]
    public void Setup()
    {
        base.Setup();
        _putClient = new PutClient("https://automationexercise.com");
    }

    [Test]
    public async Task PutToAllBRandsList_ShouldReturnResponseCode405InBody()
    {
        var body = new { };

        var json = await _putClient.PutToAllBrandLIstAsync(body);

        Assert.That(json.ContainsKey("responseCode"), Is.True, "Response JSON Does not containt 'responseCode'");
        Assert.That((int)json["responseCode"], Is.EqualTo(405), "Response code is not 405");
        Assert.That(json.ContainsKey("message"), Is.True, "Response JSON does not contain 'message'");
        Assert.That(json["message"].ToString(), Does.Contain("not supported").IgnoreCase);
    }
}

public class DeleteToVerifyTests : ApiTestFixture
{
    private DeleteToClient _deleteToClient;

    [SetUp]
    public void Setup()
    {
        base.Setup();
        _deleteToClient = new DeleteToClient("https://automationexercise.com");
    }
    
    [Test]
    public async Task DeleteToVerifyLoginAsync_ShouldReturnResponseCode405InBody()
    {
        var body = new { };
        
        var json = await _deleteToClient.DeleteToVErifyLoginAsync(body);
        
        Assert.That(json.ContainsKey("responseCode"), Is.True, "Response JSON Does not containt 'responseCode'");
        Assert.That((int)json["responseCode"], Is.EqualTo(405), "Response code is not 405");
        Assert.That(json.ContainsKey("message"), Is.True, "Response JSON does not contain 'message'");
        Assert.That(json["message"].ToString(), Does.Contain("not supported").IgnoreCase);
    }
}