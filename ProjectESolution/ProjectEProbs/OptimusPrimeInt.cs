using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs
{
    public static class OptimusPrimeInt
    {

        public static IEnumerable<int> Factorize(int n)
        {
            //http://www.mathblog.dk/project-euler-problem-3/
            /*
            long newnumm = numm;
long largestFact = 0;
 
int counter = 2;
while (counter * counter <= newnumm) {
    if (newnumm % counter == 0) {
        newnumm = newnumm / counter;
        largestFact = counter;
    } else {
        counter++;
    }
}
if (newnumm > largestFact) { // the remainder is a prime number
    largestFact = newnumm;
}
*/
        }

        public static IEnumerable<int> Primes(int max)
        {
            if (max == 0)
                yield return 0;
            else if (max == 1)
                yield return 1;

            BitArray marks = new BitArray(max);
            for(int p = 2; p < max; p++)
            {
                if (!marks[p])
                {
                    //TODO add a check, if max is greater than sqrt(int.max) then
                    //this for loop could overflow 32-bit integer
                    for(int q = p * p; q < max; q += p)
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
    }
}
