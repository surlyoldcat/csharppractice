
/*
Special Pythagorean triplet
Problem 9 
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a^2 + b^2 = c^2
For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public class Prob9
    {
        public static PythagoreanTriplet Solve()
        {
            /*
            1. a, b, c < 1000
            2. 
            */
            int maxval = 1000;
            IEnumerable<PythagoreanTriplet> triplets = GetTriplets(maxval);
            PythagoreanTriplet solution = null;
            foreach(var triplet in triplets)
            {
                if (triplet.A + triplet.B + triplet.C == maxval)
                {
                    solution = triplet;
                    break;
                }

            }
            return solution;
        }

        private static IEnumerable<PythagoreanTriplet> GetTriplets(int maxval)
        {
            //note, end could be 994 if we don't need to consider 1's
            Dictionary<int, long> squares = Utilities.GetSquares(1, 997);
            for(int a = 1; a <= maxval; a++)
            {
                for (int b = 1; b <= maxval; b++)
                {
                    long csquared = a.Pow(2) + b.Pow(2);
                    double c = Math.Sqrt((double)csquared);
                    if (c % 1 == 0)
                    {
                        //it's a square
                        int cAsInt = (int)c;
                        if (cAsInt <= maxval)
                        {
                            //we have a candidate triplet
                            yield return new PythagoreanTriplet(a, b, cAsInt);
                        }
                    }

                }
            }
        }

        public class PythagoreanTriplet
        {
            public int A { get; private set; }
            public int B { get; private set; }
            public int C { get; private set; }
            public long Asquared { get; private set; }
            public long Bsquared { get; private set; }
            public long Csquared { get; private set; }

            public PythagoreanTriplet(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
                Asquared = A.Pow(2);
                Bsquared = B.Pow(2);
                Csquared = C.Pow(2);

            }
        }
    }
}
