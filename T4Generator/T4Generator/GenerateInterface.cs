
  



using System;
using System.Collections.Generic;

namespace SampleClassLibrary
{
    public interface ISampleClient
    {
        List<int> GetUserAlertTemplates(string userContext);
        List<string> GetSomethingMagic(int integerValue);
    }
}


