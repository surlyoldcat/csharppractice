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

        public static string ShowBoundaries<T>(this IEnumerable<T> values, int n)
        {
            string begin = String.Join(",", values.Take(n));
            string end = String.Join(",", values.TakeLast(n));
            int c = values.Count();
            return $"{begin}...{end} ({c})";
        }

        // Ex: collection.TakeLast(5);
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }
    }
}
