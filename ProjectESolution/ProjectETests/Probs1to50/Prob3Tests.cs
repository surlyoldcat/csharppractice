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
        public void TestPrimeSieve()
        {
            //var primes = Prob3.PrimeSieve(1000);
            //util.WriteOut(primes.ShowBoundaries(3));

            var primes2 = Prob3.SimpleSieve(700000);
            TestUtils.WriteOut(primes2.ShowBoundaries(3));
           
            //string vals = String.Join(",", primes);
            //Utilities.TestUtils.WriteOut(vals);
            Assert.IsTrue(primes2.Length > 0);
        }

       

        [Test]
        public void TestMaxPrimeOfHugeNumber()
        {
            long num = 600851475143;
            var result = Prob3.MaxPrimeFactor(num);
        }
    }
}
