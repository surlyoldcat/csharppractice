using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs
{
    public static class OptimusPrime
    {
        
        const int NULL_IDX = int.MinValue;
        const long SIEVE_SQUAREROOT_THRESHOLD_N = 10001;

        public static IEnumerable<long> RangeSieve(int startValue, int size, IEnumerable<long> provenPrimes)
        {
            // create our Sieve of Erastothenes 'sheet'
            BitArray nonPrimes = new BitArray(size, false);

            // helper Funcs
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
                // call helper func to get first multiple of p after p^2,
                // that will be our starting point
                int startIndex = FindStartIdx(p);
                if (startIndex == NULL_IDX)
                    continue;
                
                // as with a normal sieve, go through the multiples
                // and 'mark' numbers in the array
                for(int a = startIndex; a < nonPrimes.Length; a += p)
                {
                    nonPrimes[a] = true;
                }
            }

            //iterate & return non-marked numbers
            for(int idx = 0; idx < nonPrimes.Length; idx++)
            {
                if (!nonPrimes[idx])
                {
                    yield return ValForIdx(idx);
                }
            }
            

        }


        public static long[] FactorToPrimes(long n)
        {
            long[] primeArr = PrimeFactors(n).ToArray();
            Array.Sort(primeArr);
            Array.Reverse(primeArr);
            List<long> factors = new List<long>(primeArr.Length * 2);

            // this version just starts with the highest prime < n
            // and divides down. i think it could probably be done the other
            // way, or at least more efficiently... revisit later
            long runningN = n;
            foreach (long prime in primeArr)
            {
                while (runningN >= prime && runningN % prime == 0)
                {
                    factors.Add(prime);
                    runningN /= prime;
                }
            }
            return factors.ToArray();

        }

        public static IEnumerable<long> FactorToPrimes(long n, long[] primesCache)
        {
            long[] primeArr = new long[primesCache.Length];
            primesCache.CopyTo(primeArr, 0);
            Array.Sort(primeArr);
            Array.Reverse(primeArr);
            List<long> factors = new List<long>(primeArr.Length * 2);

            long runningN = n;
            foreach (long prime in primeArr)
            {
                while (runningN >= prime && runningN % prime == 0)
                {
                    factors.Add(prime);
                    runningN /= prime;
                }
            }
            return factors;

        }

        public static IEnumerable<long> PrimeFactors(long n)
        {
            // TOOD get rid of this, combine some of the other prime factorization methods
            // into something more efficient
            if (n <= 0)
                throw new ArgumentOutOfRangeException("This function only works with non-zero positive integer values.");

            long max = n;
            if (n >= SIEVE_SQUAREROOT_THRESHOLD_N)
            {
                double d = Convert.ToDouble(n);
                double sr = Math.Ceiling(Math.Sqrt(d));
                max = Convert.ToInt64(sr);
            }
            long[] sieve = Sieve(max);
            for (long i = 0; i < sieve.Length; i++)
            {
                var prime = sieve[i];
                if (n % prime == 0)
                {
                    yield return prime;
                }
            }
            
            
        }

        
        public static IEnumerable<long> Primes(long max)
        {
            //just start enumerating prime numbers
            if (max == 0)
                yield return 0;
            else if (max == 1)
                yield return 1;

            // note, LongBitArray is an invention- functionality (and low overhead)
            // of BitArray, but it can handle 64-bit numbers (by using a collection
            // of regular BitArrays)
            LongBitArray marks = new LongBitArray(max);
            for(long p = 2; p < max; p++)
            {
                if (!marks[p])
                {
                    for(long q = p * p; q < max; q += p)
                    {
                        marks[q] = true;
                    }
                }
            }

            for (int i = 2; i < marks.Length; i++)
            {
                if (!marks[i])
                    yield return i;
            }

        }

        public static long MaxPrimeFactor(long n)
        {
            //TODO refactor into one of the existing prime factorization methods
            //600,851,475,143 is official test n
            if (n == 0)
                return 0;

            //largest possible prime factor is sqrt(n)
            double d = Convert.ToDouble(n);
            double sr = Math.Ceiling(Math.Sqrt(d));
            long maxpossible = Convert.ToInt64(sr);
            //775,147
            long[] sieve = Sieve(maxpossible);
            long solution = 1;
            for (var idx = sieve.Length - 1; idx >= 1; idx--)
            {
                var prime = sieve[idx];
                if (n % prime == 0)
                {
                    solution = prime;
                    break;
                }
            }
            
            return solution;
        }
        
       
        public static long[] Sieve(long max)
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
