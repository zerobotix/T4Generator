using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SampleClassLibrary
{
    public class BaseClient
    {
        //public BaseService(HttpClient client)
        //{
        //}

        public HttpRequestMessage CreateRequest(HttpMethod method, string url)
        {
            var request = new HttpRequestMessage(method, url);
            return request;
        }

        public T SendRequest<T>(HttpRequestMessage request)
        {
            var result = new object();

            return (T)result;
        }
    }
}
