/*
Smallest Multiple: https://projecteuler.net/problem=5
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP = ProjectEProbs.OptimusPrime;

namespace ProjectEProbs._1to50
{
    public static class Prob5
    {
        /* calculate least common multiple
        http://www.math.com/school/subject1/lessons/S1U3L3DP.html
        basically, get the prime factors of each number in the set,
        and multiply them together. if a factor appears more than once,
        multiply it the max number of times it appears in a single factor
        example:
        find LCM of 3, 9, 21 
        prime factors:
        3: 3 
        9: 3 × 3 
        21: 3 × 7
        solution = 3 x 3 x 7 = 63
       */
        public static int LCMOfRange(int lo, int hi)
        {
            int[] numbers = Enumerable.Range(lo, hi - lo + 1).ToArray();
            long[] primes = OP.PrimeFactors(hi).ToArray();
            List<long[]> factorsForEach = new List<long[]>(numbers.Length);
            foreach(int num in numbers)
            {
                factorsForEach.Add(OP.FactorToPrimes(num, primes));
            }
            //hmm, we need to build up a list of numbers to multiply;
            //but how to deal with factors that appear more than once,
            //in different frequencies?

            return -1;
        }

        private static bool TestMultiple(int n, int[] factors)
        {
            bool retval = true;
            foreach(int f in factors)
            {
                if (n % f != 0)
                    return false;
            }
            return retval;
        }


    }
}
