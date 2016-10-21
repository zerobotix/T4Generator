using System;
namespace SampleClassLibrary
{
    public interface ISampleClient
    {
        System.Collections.Generic.List<int> GetUserAlertTemplates(string userContext);
    }
}
