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
            Dictionary<int, int> factorsWithCounts = new Dictionary<int, int>(numbers.Length);
            //TODO nonrepeatedFactors can be replaced by a running product (just use division instead of List.Remove())
            foreach(int num in numbers)
            {
                //TODO THIS IS DAMN UGLY!!!
                // REPLACE with single dictionary with counts. the 2-list thing is stupid
                /*
                single dict, for each N do a simple key check for count=1, 

                */
                Dictionary<int, int> factors = OP.FactorToPrimes(num, primes).GroupBy(p => p).ToDictionary(k => (int)k.Key, v => v.Count());
                foreach(var i in factors)
                {
                    int factor = i.Key;
                    int count = i.Value;
                    if (factorsWithCounts.ContainsKey(factor))
                    {
                        if (count > factorsWithCounts[factor])
                            factorsWithCounts[factor] = count;           
                    }
                    else
                    {
                        factorsWithCounts.Add(factor, count);
                    }
                }
#if verbose
                string foo = String.Format("Prime factor counts for {0}: {1}", num, String.Join(",", factors.Select(o => $"{o.Key} ({o.Value})")));                
                System.Diagnostics.Debug.WriteLine(foo);
#endif
                
            }

#if verbose
            string allFactorsDebug = Utilities.StringifyDict<int, int>(factorsWithCounts, "factorsWithCounts");
            System.Diagnostics.Debug.WriteLine(allFactorsDebug);
#endif
            int lcm = 1;
            foreach(var kvp in factorsWithCounts)
            {
                lcm *= (int)kvp.Key.RaisePower(kvp.Value);
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
