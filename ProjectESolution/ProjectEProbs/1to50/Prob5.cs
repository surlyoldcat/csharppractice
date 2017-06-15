#define verbose
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
            long[] primes = OP.Primes(hi).ToArray();
            List<int> nonrepeatedFactors = new List<int>(numbers.Length);
            Dictionary<int, int> repeatedFactors = new Dictionary<int, int>(numbers.Length);
            //TODO nonrepeatedFactors can be replaced by a running product (just use division instead of List.Remove())
            foreach(int num in numbers)
            {
                //TODO THIS IS DAMN UGLY!!!
                // REPLACE with single dictionary with counts. the 2-list thing is stupid
                Dictionary<int, int> factors = OP.FactorToPrimes(num, primes).GroupBy(p => p).ToDictionary(k => (int)k.Key, v => v.Count());
#if verbose
                string foo = String.Format("Prime factor counts for {0}: {1}", num, String.Join(",", factors.Select(o => $"{o.Key} ({o.Value})")));                
                System.Diagnostics.Debug.WriteLine(foo);
#endif
                foreach (var kvp in factors)
                {
                    int factor = kvp.Key;
                    int count = kvp.Value;
                    if (count > 1)
                    {
                        if ((repeatedFactors.ContainsKey(factor) && count > repeatedFactors[factor])
                            || !repeatedFactors.ContainsKey(factor))
                        {                            
                            repeatedFactors[factor] = count;
                        }                                              
                    }
                    else
                    {
                        if (!nonrepeatedFactors.Contains(factor))
                            nonrepeatedFactors.Add(factor);
                    }                    
                }
                
            }
#if verbose
            string nons = String.Format("Non-repeated factors: {0}", String.Join(",", nonrepeatedFactors));
            System.Diagnostics.Debug.WriteLine(nons);
            string reps = String.Format("Repeated factors: {0}", String.Join(",", repeatedFactors.Select(o => $"{o.Key} ({o.Value})")));
            System.Diagnostics.Debug.WriteLine(reps);
            
#endif
            int lcm = nonrepeatedFactors.Aggregate(1, (acc, p) => acc * p);
            foreach(var kvp in repeatedFactors)
            {
                lcm *= kvp.Key * kvp.Value;
            }

            return lcm;
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
