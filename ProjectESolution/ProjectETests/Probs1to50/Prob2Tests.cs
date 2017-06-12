using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEProbs._1to50;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Prob2Tests")]
    public class Prob2Tests
    {
        [Test]
        public void TestMaxFibonacci()
        {
            int max = 999;
            int result = Prob2.FibonacciNumMax(max);
            Assert.IsTrue(result == 987);
            
        }

        [Test]
        public void TestMaxFibonacciLowerBounds()
        {            
            int result = Prob2.FibonacciNumMax(0);
            Assert.IsTrue(result == 0);

            int result1 = Prob2.FibonacciNumMax(1);
            Assert.IsTrue(result1 == 1);

            int result2 = Prob2.FibonacciNumMax(2);
            Assert.IsTrue(result2 == 2);
            
        }

        [Test]
        public void TestMaxFibonacciLargeN()
        {
            int max = 20000000;
            int result = Prob2.FibonacciNumMax(max);
            Assert.IsTrue(result == 14930352);
            
        }

        [Test]
        public void TestSumOfEvenFibonaccis()
        {
            int limit = 100;
            int sum = Prob2.EvenFibonacciSum(limit);
            Assert.IsTrue(sum > 0);
        }

        [Test]
        public void TestSumOfEvenFibonaccis4million()
        {
            int limit = 4000000;
            int sum = Prob2.EvenFibonacciSum(limit);
            // 4613732
            Assert.IsTrue(sum == 4613732);
        }
    }
}
