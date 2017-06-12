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
    [Category("Prob1Tests")]
    public class Prob1Tests
    {
        [Test]
        public void Test0()
        {
            int n = 0;
            int answer = Prob1.SumMultiplesOf3and5(n);
            TestUtils.WriteOut(n, answer);
            Assert.IsTrue(answer == 0);
        }

        [Test]
        public void Test10()
        {
            int n = 10;
            int answer = Prob1.SumMultiplesOf3and5(n);
            TestUtils.WriteOut(n, answer);
            Assert.IsTrue(answer == 23);
        }

        [Test]
        public void Test1000()
        {
            int n = 1000;
            int answer = Prob1.SumMultiplesOf3and5(n);
            TestUtils.WriteOut(n, answer);
            Assert.IsTrue(answer == 233168);
        }

        [Test]
        public void TestLargeN()
        {
            int n = int.MaxValue - 1;
            int answer = Prob1.SumMultiplesOf3and5(n);
            TestUtils.WriteOut(n, answer);
            Assert.IsTrue(answer == 1360072980);
        }
    }
}
