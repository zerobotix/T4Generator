using System.Collections.Generic;
using System.Net.Http;


namespace SampleLibrary
{
    public class SampleClient : BaseService ////, IAlertTemplatesClient
    {
        public SampleClient(HttpClient client)
            : base(client)
        {

        }

        public List<int> GetUserAlertTemplates(string userContext)
        {
            var url = "alerttemplates";
            var request = CreateRequest(HttpMethod.Get, url);
            var response = SendRequest<List<int>>(request);

            return response;
        }
    }
}
