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
    [Category("Problem 13")]
    public class Prob13Tests
    {
        [Test]
        public void TestLargeSum()
        {
            long val = Prob13.First10DigitsOfSum();
            Assert.AreEqual(5537376230, val);
            
        }

       
    }
        
}
