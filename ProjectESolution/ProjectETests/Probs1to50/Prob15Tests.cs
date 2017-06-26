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

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Problem 15")]
    public class Prob15Tests
    {
        [Test]
        public void TestGridSize4()
        {
            int result = Prob15.CountPathsThruGrid(4);
            Assert.AreEqual(6, result);
            
        }

        [Test]
        public void TestGridSize8()
        {
            int result = Prob15.CountPathsThruGrid(8);
            Assert.AreEqual(6, result);
            
        }

        [Test]
        public void TestGridSize20()
        {
            int result = Prob15.CountPathsThruGrid(20);
            Assert.AreEqual(6, result);
            
        }
    }
        
}
