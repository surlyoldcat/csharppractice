using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs
{
    public static class Utilities
    {
        public static string StringifyDict<Tkey, Tval>(Dictionary<Tkey, Tval> dict, string name = "")
        {
            string displayName = String.IsNullOrEmpty(name) ? "Dictionary" : name;
            StringBuilder sb = new StringBuilder($"__{displayName} Items__");
            foreach(var item in dict)
            {
                sb.AppendLine($"[{item.Key}] = {item.Value}");
            }
            return sb.ToString();
        }

        public static string StringifyList<T>(List<T> list, string delim = ",", string name="")
        {
            string displayName = String.IsNullOrEmpty(name) ? "List" : name;
            StringBuilder sb = new StringBuilder($"__{displayName} Items__");
            sb.AppendLine(String.Join(delim, list));
            return sb.ToString();
        }

        public static bool IsSquare(long n)
        {
            double root = Math.Sqrt((double)n);
            return root % 1 == 0;  //apparently you can use mod on doubles...
            
        }
        public static Dictionary<int, long> GetSquares(int start, int end)
        {

            Dictionary<int, long> squares = new Dictionary<int, long>(end - start + 1);
            for(int i = start; i <= end; i++)
            {
                squares.Add(i, i.Pow(2));
            }
            return squares;
        }

        public static string RemoveWhitespace(this string s)
        {
            return new string(s.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        public static int FirstMultipleAbove(int n, int min)
        {
            for (int x = min; x < int.MaxValue; x++)
            {
                if (x % n == 0)
                    return x;
            }
            return 0;
        }

        public static int IntegralSquareRoot(int n)
        {
            double d = Convert.ToDouble(n);
            double root = Math.Ceiling(Math.Sqrt(d));
            return Convert.ToInt32(root);
        }

        public static long IntegralSquareRoot(long n)
        {
            double d = Convert.ToDouble(n);
            double root = Math.Ceiling(Math.Sqrt(d));
            return Convert.ToInt64(root);
        }

        public static long RaisePower(this int i, int exponent)
        {
            return Enumerable.Repeat(i, exponent).Aggregate(1, (x, y) => x * y);
        }

        public static long Pow(this int x, int y)
        {
            double val = Math.Pow((double)x, (double)y);
            return Convert.ToInt64(val);
        }

        public static long Pow(this long x, int y)
        {
            double val = Math.Pow((double)x, (double)y);
            return Convert.ToInt64(val);
        }
    }
}
