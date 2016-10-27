using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SampleClassLibrary
{
    [RoutePrefix("v1")]
    public class SampleController //: ApiController
    {
        [Route("shut-the-fuck-up")]
        [HttpPost]
        public IEnumerable<DateTime> PostSomething(DateTime date)
        {
            var result = new List<DateTime> { date };

            return result;
        }

        [Route("currencies/cross-course/{fromCurrencyId:int}/{toCurrencyId:int}/{tradeDate:DateTime}")]
        public decimal GetCrossCourse(int fromCurrencyId, int toCurrencyId, DateTime tradeDate)
        {
            return 0;
        }

        [Route("alerttemplates")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>();
        }

        [HttpDelete]
        [Route("views/{id:int}")]
        public void Delete([FromUri] int id)
        {
        }

        [HttpPost]
        [Route("views/remove-dsi")]
        public void RemoveDsiColumnFromUserViews()
        {
        }

        [HttpGet]
        [Route("views/all-columns/{enumParameter}")]
        public List<SampleOutputContract> GetAllAvailableColumns(SampleEnum enumParameter)
        {
            return new List<SampleOutputContract>();
        }

        [HttpPost]
        [Route("views/save-sort")]
        public void SaveColumnSort(SampleInputContract contract)
        {
        }
    }
}
