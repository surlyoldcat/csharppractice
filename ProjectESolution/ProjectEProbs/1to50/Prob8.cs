/*
Largest Product in a series
https://projecteuler.net/problem=8
The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.

73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450

Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
   
    public class Prob8
    {
        private List<byte> Numbers { get; set; }

        public Prob8(string numberseries)
        {
            //why the F does C# make it so hard to turn a char into a string? sigh.
            Numbers = numberseries.ToArray().Select(c => byte.Parse(c.ToString())).ToList();
        }

        public Prob8Product MaxProductForWindow(int window)
        {
            //note- 9^13 is 2,541,865,828,329, so
            //make sure all products are calc'd as longs
            int endIndex = Numbers.Count() - window;
            Prob8Product max = Prob8Product.Empty();
            for(int i = 0; i < endIndex; i++)
            {
                var factors = Numbers.Skip(i).Take(window);
                if (factors.Contains((byte)0))
                    continue;
                Prob8Product prod = new Prob8Product(factors);
                if (prod.Value > max.Value)
                {
                    max = new Prob8Product(factors);
                    Debug.WriteLine($"New Max Product: {max.Value}");
                }
            }
            return max;
        }


        public class Prob8Product
        {
            public IEnumerable<byte> Factors { get; private set; }
            public long Value { get; private set; }

            internal Prob8Product(IEnumerable<byte> factors)
            {
                Factors = factors;
                long v = 1;
                //important- using Linq to one-line the product
                //does NOT work, because it doesn't do longs, just ints.
                //and it doesn't complain about overflows
                foreach(byte f in factors)
                {
                    v *= f;
                }
                Value = v;
            }

            internal static Prob8Product Empty()
            {
                byte[] f = { 0 };
                return new Prob8Product(f);
            }

            public string PrettyPrint()
            {
                string f = String.Join("*", Factors);
                return $"Result: {f} = {Value}";
            }
        }
    }
}
