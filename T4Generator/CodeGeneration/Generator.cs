﻿using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace CodeGeneration
{
    public static class Generator
    {
        public static Stopwatch Stopwatch;

        static Generator()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
        }

        public static string GenerateClientClass<T>() //where T : ApiController
        {
            var type = typeof(T);

            var name = type.Name.Remove(type.Name.IndexOf("Controller"));

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            var methodsBuilder = new StringBuilder();
            foreach (var method in methodInfos)
            {
                var generatedMethod = GenerateClientMethodForControllerAction(method);
                methodsBuilder.Append(generatedMethod);
                methodsBuilder.AppendLine();
            }
            var classMethods = methodsBuilder.ToString().Trim();

            var generatedClass = $@"
                public class {name}Client : BaseClient, I{name}Client
                {{ 
                    {classMethods}
                }}
            ";

            return generatedClass.Indent();
        }

        public static string GenerateClientInterface<T>() //where T : ApiController
        {
            var type = typeof(T);

            var name = type.Name.Remove(type.Name.IndexOf("Controller"));

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            var methodsBuilder = new StringBuilder();
            foreach (var method in methodInfos)
            {
                var returnType = Reflector.TypeName(method.ReturnType);

                var parameters = Reflector.BuildParametersList(method, false);
                var parametersWithContext = "UserContextContract userContext" + (parameters.Length == 0 ? "" : ", " + parameters);

                var methodSignature = $"{returnType} {method.Name}({parametersWithContext})";
                methodsBuilder
                    .Append(methodSignature)
                    .Append(";")
                    .AppendLine();
            }
            var interfaceMethods = methodsBuilder.ToString().Trim();

            var generatedInterface = $@"
                public interface I{name}Client
                {{
                    {interfaceMethods}
                }}
            ";

            return generatedInterface.Indent();
        }

        public static string GenerateInterface<T>() where T : class
        {
            var type = typeof(T);

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            var methodsBuilder = new StringBuilder();
            foreach (var method in methodInfos)
            {
                var methodSignature = Reflector.GetSignature(method, false);
                methodsBuilder
                    .Append(methodSignature)
                    .Append(";")
                    .AppendLine();
            }
            var methods = methodsBuilder.ToString().Trim();

            var generatedInterface = $@"
                public interface I{type.Name}
                {{ 
                    {methods}
                }}
            ";

            return generatedInterface.Indent();
        }

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

        private static string GenerateClientMethodForControllerAction(MethodInfo method)
        {
            var httpMethod = GetHttpMethod(method);

            var routeTemplate = method.GetCustomAttribute<RouteAttribute>().Template;
            var routeUrl = Regex.Replace(routeTemplate, @":\w+", string.Empty); // url/{symbolId:int} -> url/{symbolId}

            var returnType = Reflector.TypeName(method.ReturnType);

            var parameters = Reflector.BuildParametersList(method, false);
            var parametersWithContext = "UserContextContract userContext" + (parameters.Length == 0 ? "" : ", " + parameters);

            var requestContentBlock = string.Empty;
            var contractRegex = Regex.Match(parameters, @"(?<class>(\.|\w)+Contract) (?<parameter>\w+)");
            if (contractRegex.Success)
            {
                var contractClass = contractRegex.Groups["class"].Value;
                var contractParameter = contractRegex.Groups["parameter"].Value;

                requestContentBlock =  $"request.Content = new ObjectContent<{contractClass}>({contractParameter}, _formatters[0]);";
            }

            var sendRequestBlock = returnType == "void"
                ? "SendRequest(request);"
                : $"return SendRequest<{returnType}>(request);";

            var generatedMethod = $@"
                public {returnType} {method.Name}({parametersWithContext})
                {{ 
                    var url = $""{routeUrl}"";
                    var request = CreateRequest(userContext, {httpMethod}, url);
                    {requestContentBlock}
                    {sendRequestBlock}
                }}
            ";

            return generatedMethod.Indent();
        }
    }
}
