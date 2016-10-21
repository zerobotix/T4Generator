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
    public class AnotherController
    {
        ////public SampleController(IAlertTemplatesService service, IProfilerFactory profilerFactory)
        ////{
        ////    _service = service;
        ////    _profilerFactory = profilerFactory;
        ////}

        [Route("another-day")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            var result = new List<int>();

            return result;
        }

        [Route("shut-the-fuck-up")]
        [HttpPost]
        public IEnumerable<DateTime> PostSomething(DateTime date)
        {
            var result = new List<DateTime> { date };

            return result;
        }
    }
}
