using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFBD.Scripper
{
    class Program
    {
        static void Main(string[] args)
        {
            //NOTE this only runs the tests found in ScripperTests.cs;
            //putting in the ability to parse & compile C# entered
            //from a command line prompt is non-trivial, and 
            //ultimately not very useful (although it can be done...)
            Console.WriteLine("Running ObjectScripper test cases.");
            var testRunner = new ScripperTests();
            //the test runner just throws if it encounters errors
            testRunner.RunTests();
            Console.WriteLine("Done. Hit any key to exit.");
            Console.ReadKey();
        }
    }
}
