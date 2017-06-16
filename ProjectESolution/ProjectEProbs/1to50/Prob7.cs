/*
10,001st Prime
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP = ProjectEProbs.OptimusPrime;

namespace ProjectEProbs._1to50
{
    public static class Prob7
    {
        const int DEFAULT_SLICE_SIZE = 100000;

        public static long GetNthPrime(int n)
        {
            // http://www.thelowlyprogrammer.com/2012/08/primes-part-2-segmented-sieve.html

            int start = 1;
            int end = DEFAULT_SLICE_SIZE;
            int segmentSize = Utilities.IntegralSquareRoot(end);

            List<long> primes = new List<long>(segmentSize);
            primes.AddRange(OP.Primes(segmentSize));
            
            //do segmented sieve passes with ranges of DEFAULT_SLICE_SIZE length
            //until our list of primes reaches N length.

            while(primes.Count() <= n)
            {

            }
        }

        

        private static void RangeSieve(int start, int end, ref List<int> primes)
        {
                
        }

        public static long[] oldSieve(long max)
        {
            bool[] marks = new bool[max];
            for(long p = 2; p < max; p++)
            {
                if (!marks[p])
                {
                    for (long q = p * p; q < max; q += p)
                    {
                        if (!marks[q])
                            marks[q] = true;
                    }
                }
            }
            List<long> primes = new List<long>(marks.Count(m => !m));
            for (long i = 2; i < marks.Length; i++)
            {
                if (!marks[i])
                    primes.Add(i);
            }
            return primes.ToArray();
        }


    }
}
