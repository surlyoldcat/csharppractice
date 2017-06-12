using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectETests.Utilities
{
    public static class TestUtils
    {
        public static void WriteOut(string txt)
        {
            System.Diagnostics.Debug.WriteLine(txt);
            Console.WriteLine(txt);
        }

        public static void WriteOut(object inputs, object results)
        {
            string s = $"Inputs were {inputs}, results were {results}.";
            TestUtils.WriteOut(s);
        }

    }
}
