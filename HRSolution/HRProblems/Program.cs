using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRProblems.Algorithm.Easy;

namespace HRProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            IProblem prob = new ApplesAndOranges();
            string output = prob.Run();
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
