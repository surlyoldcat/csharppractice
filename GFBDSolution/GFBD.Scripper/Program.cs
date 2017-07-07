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
            //TODO should probably prompt for an input string
            Console.WriteLine("Running ObjectScripper test cases.");
            var tests = new ScripperTests();
            tests.TestAllTheThings();
            Console.WriteLine("Done. Hit any key to exit.");
            Console.ReadKey();
        }
    }
}
