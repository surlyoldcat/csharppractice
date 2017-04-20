using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork
{
    internal static class FibonacciCalc
    {
        public static List<UInt64> GetFibonacciSequence(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Value must be > 0!");
            }

            List<UInt64> seq = new List<UInt64>(number);
            for (int i = 0;i < number; i++)
            {
                if (i == 0)
                {
                    seq.Add(0);
                }
                else if (i == 1)
                {
                    seq.Add(1);
                }
                else
                {
                    seq.Add(seq[i - 2] + seq[i - 1]);        
                }
            }
            return seq;
        }

        public static UInt64 GetFibonacciNumber(int number)
        {
            var sequence = FibonacciCalc.GetFibonacciSequence(number);
            return sequence.Last();

        }

    }
}
