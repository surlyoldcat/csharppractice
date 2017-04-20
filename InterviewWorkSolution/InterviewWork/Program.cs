using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            DoTheThing();

            Console.WriteLine("Hit Enter to exit...");
            Console.ReadLine();
        }

        private static void DoTheThing()
        {
            var n = 99;
            var result = FibonacciCalc.GetFibonacciSequence(n);
            Console.WriteLine(String.Format("First {0} Fibonaccis:", n));
            Console.WriteLine(String.Join(",", result));
        }
    }
}
