using RestSharp;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Helpers.HttpHelper
{
    public class HttpHelperExtensions{

        string url;
        public HttpHelperExtensions(string url)
        {
            this.url = url;    
        }

        public async Task<RestResponse> Get()
        {
            var clientHttp = new RestClient(url);

            var reqHttp = new RestRequest();

            return await clientHttp.GetAsync(reqHttp);

        }
    }
}