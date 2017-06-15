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
    [Category("Prob5Tests")]
    public class Prob5Tests
    {

        [Test]
        public void TestMinMultiple10()
        {
            int answer = Prob5.LCMOfRange(1, 10);
            Assert.IsTrue(answer == 2520);
        }

        [Test]
        public void TestMinMultiple20()
        {
            int answer = Prob5.LCMOfRange(1, 20);
            TestUtils.WriteOut($"Min multiple of 1-20 is {answer}.");
            Assert.IsTrue(answer > 0);
        }

        [Test]
        public void TestFactorToPrimes()
        {
            long n = 63;
            var factors = OptimusPrime.FactorToPrimes(n);
            Assert.IsTrue(factors.Length == 3);
        }
    }

}
