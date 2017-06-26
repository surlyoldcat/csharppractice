/*
Longest Collatz sequence
Problem 14 
The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. 
Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob14
    {
        public static int GetCollatzSequenceLengthFor(int n)
        {
            Dictionary<long, int> sequenceLengths = GetSeedDict(n);
            int retval = GetSequenceLengthFor(n, sequenceLengths);
            return retval;

        }
        public static Prob14Result LongestCollatzSequenceUnder(int n)
        {
            // memoize sequences we've already counted
            //seed the cache with some simple ones
            Dictionary<long, int> sequenceLengths = GetSeedDict(n);


            //need to keep track of highest key AND length
            Prob14Result longestResult = new Prob14Result(3, 7);
            for (int key = 6; key < n; key++)
            {
                int c = GetSequenceLengthFor(key, sequenceLengths);
                if (c > longestResult.SequenceLength)
                    longestResult = new Prob14Result(key, c);
            }

            return longestResult;
        }

        private static int GetSequenceLengthFor(int n, Dictionary<long, int> solutions)
        {
            Func<long, long> DoEven = a => { return a / 2; };
            Func<long, long> DoOdd = b => { return 3 * b + 1; };

            long x = n;
            List<long> terms = new List<long>();

            while (x >= 1 && !solutions.ContainsKey(x))
            {
                terms.Add(x);
                x = x % 2 == 0 ? DoEven(x) : DoOdd(x);                                   
            }
            int length = terms.Count() + solutions[x];
            solutions.Add(n, length);
            return length;         
        }

        private static Dictionary<long, int> GetSeedDict(int n)
        {
            int size = n > 100 ? n / 10 : n;
            Dictionary<long, int> d = new Dictionary<long, int>(size)
            {
                { 1, 0 },
                { 2, 2 },
                { 3, 7 },
                { 4, 3 },
                { 5, 6 }
            };
            return d;
        }

        public struct Prob14Result
        {
            public int Number { get; private set; }
            public int SequenceLength { get; private set; }
            
            public Prob14Result(int n, int length)
            {
                Number = n;
                SequenceLength = length;
            }
        }
       
    }
}
