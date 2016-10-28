using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SampleClassLibrary
{
    public class BaseClient
    {
        //public BaseService(HttpClient client)
        //{
        //}

        protected readonly List<MediaTypeFormatter> _formatters;

        public HttpRequestMessage CreateRequest(UserContextContract userContext, HttpMethod method, string url)
        {
            var request = new HttpRequestMessage(method, url);
            return request;
        }

        public T SendRequest<T>(HttpRequestMessage request)
        {
            var result = new object();
            return (T)result;
        }

        public void SendRequest(HttpRequestMessage request)
        {
        }
    }
}
