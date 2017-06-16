﻿/*
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
        const int DEFAULT_SLICE_SIZE = 10000;

        public static long GetNthPrime(int n)
        {
            // http://www.thelowlyprogrammer.com/2012/08/primes-part-2-segmented-sieve.html

            long start = 1;
            long end = DEFAULT_SLICE_SIZE;
            long segmentSize = Utilities.IntegralSquareRoot(end);

            List<long> primes = new List<long>((int)segmentSize);
            primes.AddRange(OP.Primes(segmentSize));
            
            //do segmented sieve passes with ranges of DEFAULT_SLICE_SIZE length
            //until our list of primes reaches N length.

            while(primes.Count() <= n)
            {
                start = end + 1;
                end = start + DEFAULT_SLICE_SIZE;
                primes.AddRange(RangeSieve(start, end, primes));
            }
            // remember to subtract 1 to get Nth from 0-based list
            return primes[n - 1];
        }

        

        private static IEnumerable<long> RangeSieve(long startValue, int size, IEnumerable<long> provenPrimes)
        {
            bool[] marks = new bool[end - start];
            

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
