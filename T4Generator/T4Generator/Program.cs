using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web.Http;

using SampleClassLibrary;
using SampleWebApi.Controllers;

namespace T4Generator
{
    class Program
    {
        public const string source = 
            @"[Route(""alerttemplates"")]
            [HttpGet]
            public IEnumerable<AlertTemplateContract> Get()
            {
                ...
            }";


        public const string target =
            @"public List<int> GetUserAlertTemplates(string userContext)
            {
                var url = ""alerttemplates"";
                var request = CreateRequest(HttpMethod.Get, url);
                var response = SendRequest<List<int>>(request);

                return response;
            }";

        static void Main(string[] args)
        {
            //var types = Assembly.GetAssembly(typeof(SampleController)).GetTypes().Where(x => x.Name.EndsWith("AController"));
            
            //foreach (var type in types)

            var type = typeof(SampleController);

            Console.WriteLine(type.Name);
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                
            foreach (var method in methodInfos)
            {
                var result = $@"
                    { method.GetSignature() } 
                    {{ 
                    }}
                    ";
                Console.WriteLine();
                Console.WriteLine("{");

                Console.WriteLine("   var url = \"{0}\"", method.GetCustomAttribute<RouteAttribute>().Template);
                Console.WriteLine(method.GetCustomAttribute<HttpPostAttribute>());

                Console.WriteLine();
                Console.WriteLine("}");
            }
        }


    }
}
