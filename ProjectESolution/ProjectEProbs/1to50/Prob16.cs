/*
Power digit sum
Problem 16 
2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2^1000?
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob16
    {
        public static long PowerDigitSum(int n, int power)
        {
            return PowerDigitSum_Recursive(n, power);
        }

        private static long PowerDigitSum_Recursive(int n, int power)
        {
            double a = Math.Pow(n, power);
            BigInteger bigNum = new BigInteger(a);
            long sum = SumString(bigNum.ToString());
            return sum;
        }

        private static long SumString(string s)
        {
            int len = s.Length;
            long retval;
            if (len == 0)
            {
                retval = 0;
            }
            else if (len == 1)
            {
                retval = long.Parse(s);
            }
            else if (len == 2)
            {
                long num1 = long.Parse(s.First().ToString());
                long num2 = long.Parse(s.Last().ToString());
                retval = num1 + num2;
            }
            else
            {
                int mid = len / 2;
                long firstHalfSum = SumString(s.Substring(0, mid));
                long secondHalfSum = SumString(s.Substring(mid));
                retval = firstHalfSum + secondHalfSum;
            }
            return retval;
            
        }
    }
}
