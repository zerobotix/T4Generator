using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SampleWebApi.Models;
using SampleWebApi.Providers;
using SampleWebApi.Results;

namespace SampleWebApi.Controllers
{
    [RoutePrefix("v1")]
    ////[OperationAuthorization(OperationTypes.ManageTemplates)]
    public class SampleController
    {
        ////public SampleController(IAlertTemplatesService service, IProfilerFactory profilerFactory)
        ////{
        ////    _service = service;
        ////    _profilerFactory = profilerFactory;
        ////}

        [Route("currencies/cross-course/{fromCurrencyId:int}/{toCurrencyId:int}/{tradeDate:DateTime}")]
        public decimal GetCrossCourse(int fromCurrencyId, int toCurrencyId, DateTime tradeDate)
        {
            return 0;
        }

        [Route("alerttemplates")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            var result = new List<int>();

            return result;
        }
    }
}
