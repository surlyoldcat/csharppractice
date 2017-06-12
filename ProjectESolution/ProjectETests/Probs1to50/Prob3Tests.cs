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
    [Category("Prob3Tests")]
    public class Prob3Tests
    {
        [Test]
        public void TestPrimeSieve()
        {
            var primes = Prob3.PrimeSieve(10000);
            //string vals = String.Join(",", primes);
            //Utilities.TestUtils.WriteOut(vals);
            Assert.IsTrue(primes.Length > 0);
        }

        [Test]
        public void TestMaxPrimeOfHugeNumber()
        {
            long num = 600851475143;
            var result = Prob3.MaxPrimeFactor(num);
        }
    }
}
