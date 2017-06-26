/*
Lattice paths
Problem 15 
Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
https://projecteuler.net/problem=15

How many such routes are there through a 20×20 grid?
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob15
    {
        /*
            So, this is a lattice path problem, which according to the WWW means calculating a Binomial Coefficient
            he number of lattice paths from the origin (0,0) to a point (a,b) is the binomial coefficient {(a+b)/a}.
            
            the value  of the Binomial Coefficient of n/k (n choose k) is
            n!/((n-k)!*k!)

            so for our problem, we want a BC value for {40/20} 40 choose 20
        */

        public static long CountPathsThruGridToPoint(int a, int b)
        {

            long n = a + b;
            long k = a;
            BigInteger numerator = Factorial(n);
            BigInteger denominator = Factorial(n - k) * Factorial(k);
            BigInteger binomCoeff = numerator / denominator;

            return (long)binomCoeff;

        }

        public static BigInteger Factorial(long n)
        {
            if (n < 3) { return n * 1; }
            else if (n == 3) { return 6; }
            else if (n == 4) { return 24; }
            else
            {
                return n * Factorial(n - 1);
            }
            
        }
    }
}
