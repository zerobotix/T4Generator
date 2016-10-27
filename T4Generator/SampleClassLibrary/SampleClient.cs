using System.Collections.Generic;
using System.Net.Http;


namespace SampleClassLibrary
{
    public class SampleClient : BaseClient, SampleClassLibrary.ISampleClient
    {
        //public SampleClient(HttpClient client)
        //    : base(client)
        //{
        //}

        public List<int> GetUserAlertTemplates(UserContextContract userContext)
        {
            var url = "alerttemplates";
            var request = CreateRequest(userContext, HttpMethod.Get, url);
            var response = SendRequest<List<int>>(request);

            return response;
        }

        public List<string> GetSomethingMagic(int integerValue)
        {
            return new List<string>();
        }
    }
}
