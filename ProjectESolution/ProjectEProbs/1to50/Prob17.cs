/*
Number letter counts
Problem 17 
If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?


NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
The use of "and" when writing out numbers is in compliance with British usage.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob17
    {
        /*
        notes:
            - should use memoization, or is that overkill?
    */
        public static int GetLetterCount(int startNum, int endNum)
        {
            int count = 0;
            for (int a = startNum; a <= endNum; a++)
            {
                string numstring = a.ToText();
                System.Diagnostics.Debug.WriteLine($"{a} is {numstring}");
                int n = numstring.RemoveWhitespace().Replace("-", "").Length;
                count += n;
            }
            return count;
        }
    }

    public static class NumberTextExtensions
    {
        private static readonly Dictionary<int, string> Ones = new Dictionary<int, string>
        {
            {1, "one" },
            {2, "two" },
            {3, "three" },
            {4, "four" },
            {5, "five" },
            {6, "six" },
            {7, "seven" },
            {8, "eight" },
            {9, "nine" }
        };
        private static readonly Dictionary<int, string> Teens = new Dictionary<int, string>
        {
            {10, "ten" },
            {11, "eleven" },
            {12, "twelve" },
            {13, "thirteen" },
            {14, "fourteen" },
            {15, "fifteen" },
            {16, "sixteen" },
            {17, "seventeen" },
            {18, "eighteen" },
            {19, "nineteen" }
        };
        private static readonly Dictionary<int, string> Decades = new Dictionary<int, string>
        {
            {20, "twenty" },
            {30, "thirty" },
            {40, "forty" },
            {50, "fifty" },
            {60, "sixty" },
            {70, "seventy" },
            {80, "eighty" },
            {90, "ninety" }
        };

        public static string ToText(this int i)
        {
            if (i > 9999 || i < 1)
                throw new ArgumentException("This method currently only supports numbers 1-9999");

            return Stringify(i);
        }

        private static string Stringify(int num)
        {
            if (num < 10)
            {
                return Ones[num];
            }
            else if (num < 20)
            {
                return Teens[num];
            }
            else if (num < 100)
            {
                int rem = num % 10;
                if ( rem == 0)
                {
                    return Decades[num];
                }
                else
                {
                    string s = String.Format("{0}-{1}", Decades[num - rem], Stringify(rem));
                    return s;
                }
            }
            else if (num < 1000)
            {
                int rem = num % 100;
                int hun = num / 100;
                if (rem == 0)
                {
                    return String.Format("{0} hundred", Ones[hun]);
                }
                else
                {
                    return String.Format("{0} hundred and {1}", Ones[hun], Stringify(rem));
                }

            }
            else if (num < 10000)
            {
                int rem = num % 1000;
                int thou = num / 1000;
                if (rem == 0)
                {
                    return String.Format("{0} thousand", Ones[thou]);
                }
                else
                {
                    return String.Format("{0} thousand {1}", Ones[thou], Stringify(rem));
                }
            }
            else
            {
                return null;
            }
        }
    }
}
