/*
Summation of primes
Problem 10 
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob10
    {
        public static long SumOfPrimes(int n)
        {
            
            var primes = OptimusPrime.Primes(n);            
            long sum = primes.Sum();
            return sum;
        }
    }
}
