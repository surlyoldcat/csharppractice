using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEProbs._1to50;
using ProjectETests.Utilities;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Prob3Tests")]
    public class Prob3Tests
    {
        [Test]
        public void TestPrimeSieveLargeN()
        {
            var primes2 = Prob3.SimpleSieve(50000);
            TestUtils.WriteOut(primes2.ShowBoundaries(3));
           
            Assert.IsTrue(primes2.Length > 0);
        }

        [Test]
        public void TestPrimeSieveFirst100()
        {
            var primes = Prob3.SimpleSieve(100);
            TestUtils.WriteOut(primes.ShowBoundaries(3));
            
            Assert.IsTrue(primes.Length == 25);
        }

       

        [Test]
        public void TestMaxPrimeOfHugeNumber()
        {
            long num = 600851475143;
            var result = Prob3.MaxPrimeFactor(num);
            TestUtils.WriteOut($"Max prime factor of {num} is {result}");
            //6857
        }
    }
}
