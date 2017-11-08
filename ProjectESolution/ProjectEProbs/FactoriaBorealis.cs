using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs
{
    public static class FactoriaBorealis
    {
        public static BigInteger Factorial(long n)
        {
            //TODO make tail-recursive (add private func with accumulator arg)
            if (n < 3) { return n * 1; }
            else if (n == 3) { return 6; }
            else if (n == 4) { return 24; }
            else
            {
                return n * Factorial(n - 1);
            }
            
        }
    }
}
