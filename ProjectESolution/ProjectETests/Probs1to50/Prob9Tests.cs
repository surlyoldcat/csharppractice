
/*
Special Pythagorean triplet
Problem 9 
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a2 + b2 = c2
For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
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
    [Category("Problem 9")]
    public class Prob9Tests
    {

        [Test]
        public void TestPythagoreanTriplet1000()
        {
            var triplet = Prob9.Solve();
            long solution = triplet.A * triplet.B * triplet.C;
            TestUtils.WriteOut("Problem 9 solution: {solution}");
            // 31875000
        }
    }
        
}
