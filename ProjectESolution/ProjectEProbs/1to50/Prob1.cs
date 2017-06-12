/*
 If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEProbs._1to50
{
    public static class Prob1
    {
        public static int SumMultiplesOf3and5(int n)
        {
            if (n < 3)
                return 0;
            else if (n < 5)
                return 3;

            int sum = 0;
            for (var a = 1; a < n; a++)
            {
                if (a % 3 == 0 || a % 5 == 0)
                    sum += a;
            }
            return sum;
        }

        public static int[] GetMultiplesOf3and5(int n)
        {
            if (n < 3)
                return new int[] { };
            else if (n < 5)
                return new int[] { 3 };

            List<int> multiples = new List<int>(n);
            for (var a = 1; a < n; a++)
            {
                if (a % 3 == 0 || a % 5 == 0)
                    multiples.Add(a);
            }
            return multiples.ToArray();
        }

    }
}
