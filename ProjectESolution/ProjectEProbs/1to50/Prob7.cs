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
                primes.AddRange(OP.RangeSieve(rangeStart, segmentSize, primes));
            }
            // remember to subtract 1 to get Nth from 0-based list
            return primes[n - 1];
        }

        

    }
}
