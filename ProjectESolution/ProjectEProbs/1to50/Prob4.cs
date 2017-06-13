/*
https://projecteuler.net/problem=4
Largest Palindrome Product
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    /*
        this solution is pretty verbose. i imagine it could be reduced to something quite a bit more concise.
    */
    public static class Prob4
    {
        public static int LargestPalindromeProduct(int numFactorDigits)
        {
            int maxFactor = MaxNumberForDigits(numFactorDigits);
            int minFactor = MinNumberForDigits(numFactorDigits);

            int maxProduct = maxFactor * maxFactor;
            //note, this array is sorted descending
            //int[] pals = PalindromesAtOrBelow(maxFactor * maxFactor);
            foreach(int pal in PalindromesAtOrBelow(maxProduct))
            {
                if (TestPalindrome(pal, minFactor, maxFactor))
                    return pal;
            }
            
            return 0;
        }

        public static bool TestPalindrome(int pal, int min, int max)
        {
            for(int f = max; f >= min; f--)
            {
                if (pal % f == 0)
                {
                    //f is factor of this palindrome; is
                    //the other factor in range?
                    int f2 = pal / f;
                    if (min <= f2 && f2 <= max)
                        return true;
                }
            }
            return false;
        }

        //public static int[] PalindromesAtOrBelow(int max)
        public static IEnumerable<int> PalindromesAtOrBelow(int max)
        {
            //List<int> pals = new List<int>(max / 2);
            for (int n = max; n > 0; n--)
            {
                if (n.IsPalindrome())
                    //pals.Add(n);
                    yield return n;
            }
            //return pals.ToArray();
        }

        public static int MinNumberForDigits(int numdigits)
        {
            if (numdigits < 1)
                return 0;

            string s = "1";
            for (int i = 1; i < numdigits; i++)
            {
                s += "0";
            }
            return int.Parse(s);

        }

        public static int MaxNumberForDigits(int numdigits)
        {
            if (numdigits < 1)
                return 0;

            string s = String.Empty;
            for (int i = 0; i < numdigits; i++)
            {
                s += "9";
            }
            return int.Parse(s);
        }

        public static bool IsPalindrome(this int n)
        {
            var digits = n.ToString().ToCharArray();
            var reversed = digits.Reverse().ToArray();
            for(int a = 0; a < digits.Length; a++)
            {
                if (digits[a] != reversed[a])
                    return false;
            }
            return true;

        }
    }
}
