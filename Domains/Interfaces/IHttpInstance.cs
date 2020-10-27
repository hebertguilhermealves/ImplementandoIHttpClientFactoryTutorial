using System.Net.Http;
using System.Threading.Tasks;

namespace Domains.Interfaces
{
    public interface IHttpInstance
    {

        public Task<HttpResponseMessage> Get(string uri, string client);
        public Task<HttpResponseMessage> Post(string uri);
        public Task<HttpResponseMessage> Put(string uri);
        public Task<HttpResponseMessage> Delete(string uri);

    }
}
