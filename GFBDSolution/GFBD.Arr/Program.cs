using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFBD.Arr
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Usage: Either run it without args and follow instructions,
            or pass a single arg, either "--test" or the string to be 
            transmogrified.
            */
            string value = null;
            if (args.Length > 0)
            {
                value = args[0];
            }
            else
            {
                Console.WriteLine("Enter a string to transform, or '--test' to run tests.");
                value = Console.ReadLine();
            }

            //run the test cases or transform the supplied string
            if (value == "--test")
            {
                Console.WriteLine("Running test cases...");
                var tester = new TransformerTests();
                tester.RunTests();
            }
            else
            {
                Console.WriteLine($"Transforming string: {value}");
                string result = new string(Transformer.Transform(value.ToCharArray()));               
                Console.WriteLine($"Result: {result}");
            }
            Console.WriteLine("All done! Hit any key to exit...");
            Console.ReadKey();
            
        }


    }
}
