using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.InMemoryTests
{
    public abstract class FeatureBase
    {
        private readonly WebApplicationFactory<Startup> _factory;
        protected HttpResponseMessage _lastResponseMessage;

        protected FeatureBase()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        protected async Task<TResponse> SendAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var client = _factory.CreateClient();

            var requestContent = new StringContent(JsonConvert.SerializeObject(request));
            _lastResponseMessage = await client.PostAsync(uri, requestContent);

            var responseContent = await _lastResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}