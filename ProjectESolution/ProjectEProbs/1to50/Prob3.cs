/*
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600,851,475,143 ?
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob3
    {
        private const int SIEVE_MAX = 10000;

        public static long MaxPrimeFactor(long n)
        {
            //600,851,475,143 is official test n
            if (n == 0)
                return 0;

            //largest possible prime factor is sqrt(n)
            double d = Convert.ToDouble(n);
            double sr = Math.Ceiling(Math.Sqrt(d));
            long maxpossible = Convert.ToInt64(sr);
            //775,147
            long[] sieve = SimpleSieve(maxpossible);
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

            // how to bridge gap between sqrt of big number
            // and precached list of known primes?



            return solution;
        }

        
        public static long[] SimpleSieve(long max)
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

        public static int[] PrimeSieve(int n)
        {
            List<int> nums = Enumerable.Range(2, n - 2).ToList();
            
            int p = 2;
            while (p < n)
            {
                for (int q = p*p; q < n; q+=p)
                {
                    if (nums.Contains(q))
                        nums.Remove(q);
                }
                //advance p to next (prime) number in nums
                int nextPindex = nums.IndexOf(p) + 1;
                if (nextPindex >= nums.Count)
                {
                    //we're out of nums
                    break;
                }
                p = nums[nextPindex];
            }
            return nums.ToArray();
            

        }

        
    }
}
