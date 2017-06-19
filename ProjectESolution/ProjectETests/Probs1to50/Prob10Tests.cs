/*
Summation of primes
Problem 10 
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectEProbs;
using ProjectEProbs._1to50;
using ProjectETests.Utilities;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Problem 10")]
    public class Prob10Tests
    {
        [Test]
        public void TestSumOfPrimes10()
        {
            int n = 10;
            long solution = GetSum(n);
            Assert.AreEqual(17, solution);
            TestUtils.WriteOut($"Sum of first {n} primes is: {solution}");
            
        }

        [Test]
        public void TestSumOfPrimes100()
        {
            int n = 100;
            long solution = GetSum(n);
            TestUtils.WriteOut($"Sum of first {n} primes is: {solution}");
            
        }

        [Test]
        public void TestSumOfPrimes10000()
        {
            int n = 10000;
            long solution = GetSum(n);
            TestUtils.WriteOut($"Sum of first {n} primes is: {solution}");
            
        }

        [Test]
        public void TestSumOfPrimes2000000()
        {
            int n = 2000000;
            long solution = GetSum(n);
            TestUtils.WriteOut($"Sum of first {n} primes is: {solution}");
            Assert.AreEqual(142913828922, solution);    
        }

        private long GetSum(int n)
        {
            return Prob10.SumOfPrimes(n);
        }
    }
        
}
