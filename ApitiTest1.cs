using System.Net;
using ApiTests;
using RestSharp;
using Newtonsoft.Json.Linq;


namespace ApiTests
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public JObject GetAllProducts()
        {
            var request = new RestRequest("/api/productsList", Method.Get);
            var response = _client.Execute(request);

            if (!response.IsSuccessful)
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

            return JObject.Parse(response.Content);
        }
    }
}

public class PostClient
{
    private readonly RestClient _client;

    public PostClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<JObject> PostToAllProductsAsync(object body)
    {
        var request = new RestRequest("/api/productsList", Method.Post);
        request.AddJsonBody(body);

        var response = await _client.ExecuteAsync(request);

        Console.WriteLine($"StatusCode: {response.StatusCode}");
        Console.WriteLine($"Content: {response.Content}");

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
        }
        return JObject.Parse(response.Content);
    }
}

public class GetAllClient
{
    private readonly RestClient _client;

    public GetAllClient(string baseUrl)

    {
        _client = new RestClient(baseUrl);
    }

    public async Task<JObject> GetAllBrandsListAsync(object body)
    {
        var request = new RestRequest("api/brandsList", Method.Get);
        request.AddJsonBody(body);

        var response = await _client.ExecuteAsync(request);

        Console.WriteLine($"StatusCode: {response.StatusCode}");
        Console.WriteLine($"Content: {response.Content}");

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Request successfull with status code {response.StatusCode}");
        }

        return JObject.Parse(response.Content);
    }
}

public class PutClient
{
    private readonly RestClient _client;

    public PutClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<JObject> PutToAllBrandLIstAsync(object body)
    {
        var request = new RestRequest("api/brandsList", Method.Put);
        
        var response = await _client.ExecuteAsync(request);

        Console.WriteLine($"StatusCode: {response.StatusCode}");
        Console.WriteLine($"Content: {response.Content}");

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Request successfull with status code {response.StatusCode}");
        }

        return JObject.Parse(response.Content);
    }
}

public class DeleteToClient
{
    private readonly RestClient _client;

    public DeleteToClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<JObject> DeleteToVErifyLoginAsync(object body)
    {
        var request = new RestRequest("api/verifyLogin");

        var response = await _client.ExecuteAsync(request);

        Console.WriteLine($"StatusCode: {response.StatusCode}");
        Console.WriteLine($"Content: {response.Content}");

        if (!response.IsSuccessful)

        {
            throw new HttpRequestException($"Request successfull with status code{response.StatusCode}");
        }

        return JObject.Parse(response.Content);
    }
}