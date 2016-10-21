using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Http;

using CodeGeneration;

using SampleClassLibrary;

namespace T4Generator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var generatedClass = Generator.GenerateClientClassForController<SampleController>();
            Console.WriteLine(generatedClass);
            Console.ReadKey();
        }
    }
}
