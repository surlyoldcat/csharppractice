/*
10,001st Prime
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?

*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP = ProjectEProbs.OptimusPrime;

namespace ProjectEProbs._1to50
{
    public static class Prob7
    {
        const int DEFAULT_SLICE_SIZE = 100000;
        const int NULL_IDX = int.MinValue;


        public static long GetNthPrime(int n, int segmentSize = DEFAULT_SLICE_SIZE)
        {
            // http://www.thelowlyprogrammer.com/2012/08/primes-part-2-segmented-sieve.html

            
            List<long> primes = new List<long>(n);
            primes.AddRange(OP.Primes(segmentSize));

            //do segmented sieve passes with ranges of DEFAULT_SLICE_SIZE length
            //until our list of primes reaches N length.
            int rangeStart = 1;
            while(primes.Count() <= n)
            {
                rangeStart += segmentSize;
                primes.AddRange(RangeSieve(rangeStart, segmentSize, primes));
            }
            // remember to subtract 1 to get Nth from 0-based list
            return primes[n - 1];
        }

        

        private static IEnumerable<long> RangeSieve(int startValue, int size, IEnumerable<long> provenPrimes)
        {
            //TODO move this into OptimusPrime
            BitArray nonPrimes = new BitArray(size, false);
            Func<int, int> ValForIdx = (idx) => { return startValue + idx; };
            Func<int, int> IdxForVal = (val) =>
            {
                int retval = val - startValue;
                if (retval < 0 || retval >= nonPrimes.Length)
                {
                    retval = NULL_IDX;
                }
                return retval;
            };
            Func<int, int> FindStartIdx = (p) =>
            {
                int s = (int)p.Pow(2);
                if (s < startValue)
                    s = Utilities.FirstMultipleAbove(p, startValue);
                return IdxForVal(s);                
            };

            foreach(int p in provenPrimes)
            {
                int startIndex = FindStartIdx(p);
                if (startIndex == NULL_IDX)
                    continue;
                
                for(int a = startIndex; a < nonPrimes.Length; a += p)
                {
                    nonPrimes[a] = true;
                }
            }
            for(int idx = 0; idx < nonPrimes.Length; idx++)
            {
                if (!nonPrimes[idx])
                {
                    yield return ValForIdx(idx);
                }
            }
            

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
