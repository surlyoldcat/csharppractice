/*
Lattice paths
Problem 15 
Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
https://projecteuler.net/problem=15

How many such routes are there through a 20×20 grid?

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
using System.Numerics;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Problem 15")]
    public class Prob15Tests
    {
        [Test]
        public void TestSmallGrid()
        {
            var result = Prob15.CountPathsThruGridToPoint(2,2);
            Assert.AreEqual(6, result);
            
        }

        [Test]
        public void TestMediumGrid()
        {
            var result = Prob15.CountPathsThruGridToPoint(8, 8);
            Assert.AreEqual(12870, result);
            
        }

        [Test]
        public void TestLargeGrid()
        {
            var result = Prob15.CountPathsThruGridToPoint(20, 20);
            Assert.AreEqual(137846528820, result);
            
        }

        [Test]
        public void TestFactorial()
        {
            var result = Prob15.Factorial(5);
            Assert.AreEqual(120, result);

            result = Prob15.Factorial(6);
            Assert.AreEqual(720, result);

            result = Prob15.Factorial(10);
            Assert.AreEqual(3628800, result);


        }
    }
        
}
