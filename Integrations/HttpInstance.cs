using Domains.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integrations
{
    public class HttpInstance : IHttpInstance
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpInstance()
        {

        }
        public HttpInstance(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public Task<HttpResponseMessage> Delete(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> Get(string uri, string client)
        {
            var _client = _httpClientFactory.CreateClient(client);
            var response = await _client.GetAsync(_client.BaseAddress + uri);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                var retornoErro = response.EnsureSuccessStatusCode();
                return retornoErro;
            }
        }

        public Task<HttpResponseMessage> Post(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Put(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
