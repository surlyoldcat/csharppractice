/*
Sum square difference
The sum of the squares of the first ten natural numbers is,

1^2 + 2^2 + ... + 10^2 = 385
The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)^2 = 55^2 = 3025
Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob6
    {
        public static long SolveFor(int n)
        {
            int[] numbers = Enumerable.Range(1, n).ToArray();
            int sum = 0;
            long sumOfSquares = 0;
            foreach(int number in numbers)
            {
                sum += number;
                sumOfSquares += number.Pow(2);
            }
            long squareOfSum = sum.Pow(2);
            return squareOfSum - sumOfSquares;
            
        }
    }
}
