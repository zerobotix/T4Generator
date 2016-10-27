using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeGeneration;

using SampleClassLibrary;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //var generatedCode = Generator.GenerateClientClassForController<SampleController>();
            var generatedCode = Generator.GenerateInterface<SampleController>();
            Console.WriteLine(generatedCode);
            Console.ReadKey();
        }
    }
}
