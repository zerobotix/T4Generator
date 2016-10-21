

using System;
using System.Collections.Generic;
using System.Net.Http;

using SampleClassLibrary;

namespace Clients
{
    public class SampleClient : BaseClient //, ISampleClient
{
    public IEnumerable<System.DateTime> PostSomething(UserContextContract userContext,System.DateTime date) 
    { 
        var url = $"shut-the-fuck-up";
        var request = CreateRequest(userContext, HttpMethod.Post, url);
        return SendRequest<IEnumerable<System.DateTime>>(request);
    }

    public decimal GetCrossCourse(UserContextContract userContext,int fromCurrencyId, int toCurrencyId, System.DateTime tradeDate) 
    { 
        var url = $"currencies/cross-course/{fromCurrencyId}/{toCurrencyId}/{tradeDate}";
        var request = CreateRequest(userContext, HttpMethod.Get, url);
        return SendRequest<decimal>(request);
    }

    public IEnumerable<int> Get(UserContextContract userContext,) 
    { 
        var url = $"alerttemplates";
        var request = CreateRequest(userContext, HttpMethod.Get, url);
        return SendRequest<IEnumerable<int>>(request);
    }

    public void Delete(UserContextContract userContext,int id) 
    { 
        var url = $"views/{id}";
        var request = CreateRequest(userContext, HttpMethod.Delete, url);
        SendRequest(request);
    }

    public void RemoveDsiColumnFromUserViews(UserContextContract userContext,) 
    { 
        var url = $"views/remove-dsi";
        var request = CreateRequest(userContext, HttpMethod.Post, url);
        SendRequest(request);
    }

    public List<SampleClassLibrary.SampleOutputContract> GetAllAvailableColumns(UserContextContract userContext,SampleClassLibrary.SampleEnum enumParameter) 
    { 
        var url = $"views/all-columns/{enumParameter}";
        var request = CreateRequest(userContext, HttpMethod.Get, url);
        return SendRequest<List<SampleClassLibrary.SampleOutputContract>>(request);
    }

    public void SaveColumnSort(UserContextContract userContext,SampleClassLibrary.SampleInputContract contract) 
    { 
        var url = $"views/save-sort";
        var request = CreateRequest(userContext, HttpMethod.Post, url);
        SendRequest(request);
    }
}

}


