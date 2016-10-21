using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeGeneration
{
    public static class Generator
    {
        private static string GetHttpMethod(MethodInfo method)
        {
            string verb = nameof(HttpMethod.Get);

            if (method.GetCustomAttribute<HttpGetAttribute>() != null)
                verb = nameof(HttpMethod.Get);
            else if (method.GetCustomAttribute<HttpPostAttribute>() != null)
                verb = nameof(HttpMethod.Post);
            else if (method.GetCustomAttribute<HttpPutAttribute>() != null)
                verb = nameof(HttpMethod.Put);
            else if (method.GetCustomAttribute<HttpDeleteAttribute>() != null)
                verb = nameof(HttpMethod.Delete);

            var httpMethod = $"{nameof(HttpMethod)}.{verb}";

            return httpMethod;
        }

        public static string GenerateClientMethodForControllerAction(MethodInfo method)
        {
            var httpMethod = GetHttpMethod(method);

            var routeTemplate = method.GetCustomAttribute<RouteAttribute>().Template;
            var routeUrl = Regex.Replace(routeTemplate, @":\w+", string.Empty); // remove type constraints

            var methodSignatureWithoutParameters = Reflector.BuildReturnSignature(method, true, false);
            var parameters = Reflector.BuildParametersList(method, false);
            var methodSignature = $"{ methodSignatureWithoutParameters }(UserContextContract userContext,{parameters})";

            var returnType = Reflector.TypeName(method.ReturnType);
            var isVoid = returnType == "void";

            var sendRequestBlock = isVoid
                ? "SendRequest(request);"
                : $"return SendRequest<{ returnType }>(request);";

            var generatedMethod = $@"
                { methodSignature } 
                {{ 
                    var url = $""{ routeUrl }"";
                    var request = CreateRequest(userContext, { httpMethod }, url);

                    {sendRequestBlock}
                }}
            "; // count of extra-spaces is calculated from this line

            // remove extra spaces at the start of the line
            var lines = generatedMethod.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var extraSpacesCount = lines.Last().Length;
            var linesWithoutSpaces = lines.Select(x => x.Remove(0, extraSpacesCount));
            var result = string.Join(Environment.NewLine, linesWithoutSpaces);

            return result;
        }

        public static string GenerateClientClassForController<T>() where T : class // where T : Controller
        {
            var result = new StringBuilder();
            var type = typeof(T);

            var name = type.Name.Remove(type.Name.IndexOf("Controller"));
            var classSignature = $@"public class {name}Client : BaseClient //, I{name}Client";

            result.AppendLine(classSignature);
            result.Append("{");

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methodInfos)
            {
                var generatedMethod = GenerateClientMethodForControllerAction(method);
                result.AppendLine();
                result.Append(generatedMethod);
            }

            result.AppendLine("}");

            return result.ToString();
        }
    }
}
