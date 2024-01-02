using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using TweetsOnThisDay.Interfaces;
using TweetsOnThisDay.Models;

namespace TweetsOnThisDay.Services;
internal class HtmlToImageService : IHtmlToImageService
{
    private const string BaseUri = "https://hcti.io/v1/image";

    private readonly IRestClient _client;
    private readonly string _userId;
    private readonly string _apiKey;

    public HtmlToImageService(IRestClient client, IConfiguration configuration)
    {
        _client = client;

        _userId = configuration.GetValue<string>("HctiUserId");
        _apiKey = configuration.GetValue<string>("HctiApiKey");
    }

    public async Task<byte[]> GetImageFromHtmlAsync(string html)
    {
        var htmlImage = await _client.PostAsync<HtmlToImageResponseModel>(new RestRequest(BaseUri, Method.Post)
        {
            RequestFormat = DataFormat.Json,
            Authenticator = new HttpBasicAuthenticator(_userId, _apiKey)
        }
        .AddBody(new { Html = html }));

        var image = await _client.GetAsync(new RestRequest(htmlImage.Url));
        return image.RawBytes;
    }
}
