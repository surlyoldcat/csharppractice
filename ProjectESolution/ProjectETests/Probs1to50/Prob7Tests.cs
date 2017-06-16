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
            long result = Prob6.SolveFor(n);
            Assert.AreEqual(2640, result);
        }


        [Test]
        public void TestSGet10001stPrime()
        {
            int n = 10001;
            long result = Prob6.SolveFor(n);
            Assert.AreEqual(25164150, result);
            TestUtils.WriteOut($"Sum square diff for n={n} is {result}.");
        }}
}
