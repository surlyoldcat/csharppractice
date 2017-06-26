/*
Power digit sum
Problem 16 
2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2^1000?
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
using System.Numerics;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Problem 16")]
    public class Prob16Tests
    {
        [Test]
        public void TestSmallExponent()
        {
            var result = Prob16.PowerDigitSum(2, 15);
            Assert.AreEqual(26, result);
            
        }

        [Test]
        public void TestBigassExponent()
        {
            var result = Prob16.PowerDigitSum(2, 1000);
            Assert.AreEqual(1366, result);
        }
        
    }
        
}
