using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectEProbs._1to50;
using ProjectETests.Utilities;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Problem 7")]
    public class Prob7Tests
    {
        [Test]
        public void TestGet6thPrime()
        {
            int n = 6;
            long result = Prob7.GetNthPrime(n);
            Assert.AreEqual(13, result);
        }


        [Test]
        public void TestSGet10001stPrime()
        {
            int n = 10001;
            long result = Prob7.GetNthPrime(n);
            Assert.IsTrue(result > 1);
            //Assert.AreEqual(25164150, result);
            TestUtils.WriteOut($"10,001st prime is {result}.");
        }}
}
