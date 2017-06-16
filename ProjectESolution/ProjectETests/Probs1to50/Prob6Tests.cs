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
    [Category("Problem 6")]
    public class Prob6Tests
    {
        [Test]
        public void TestSquareSumDiff10()
        {
            int n = 10;
            long result = Prob6.SolveFor(n);
            Assert.AreEqual(2640, result);
        }


        [Test]
        public void TestSquareSumDiff100()
        {
            int n = 100;
            long result = Prob6.SolveFor(n);
            Assert.AreEqual(25164150, result);
            TestUtils.WriteOut($"Sum square diff for n={n} is {result}.");
        }}
}
