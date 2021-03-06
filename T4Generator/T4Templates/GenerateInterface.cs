﻿// autogenerated

using System;
using System.Collections.Generic;
using System.Net.Http;

using SampleClassLibrary;

namespace Clients
{
    public interface ISampleController
    { 
        IEnumerable<System.DateTime> PostSomething(System.DateTime date);
        decimal GetCrossCourse(int fromCurrencyId, int toCurrencyId, System.DateTime tradeDate);
        IEnumerable<int> Get();
        void Delete(int id);
        void RemoveDsiColumnFromUserViews();
        List<SampleClassLibrary.SampleOutputContract> GetAllAvailableColumns(SampleClassLibrary.SampleEnum enumParameter);
        void SaveColumnSort(SampleClassLibrary.SampleInputContract contract);
    }
}


