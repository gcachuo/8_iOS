using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary_8iOs.Foursquareclient.DataAccess
{
    class HttpHandler
    {
        public static async Task<HttpResponseMessage> GetHttpResponse(string url)
        {
            var httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            var httpResponse = await httpClient.SendAsync(request);
            return httpResponse;
        }
    }
}
