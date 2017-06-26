/*
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
    [Category("Problem 14")]
    public class Prob14Tests
    {
        [Test]
        public void TestSequenceLengthFor13()
        {
            int val = Prob14.GetCollatzSequenceLengthFor(13);
            Assert.AreEqual(10, val);
            
        }


        [Test]
        public void TestLongestUnder1000()
        {
            var result= Prob14.LongestCollatzSequenceUnder(1000);

            Assert.AreEqual(871, result.Number);
            
        }
       
        [Test]
        public void TestLongestUnder1000000()
        {
            var result = Prob14.LongestCollatzSequenceUnder(1000000);
            string s = $"Longest Collatz sequence under 1000000 starts with {result.Number}, length is {result.SequenceLength}.";
            Utilities.TestUtils.WriteOut(s);
            // 837799, length of chain is 525
            Assert.AreEqual(837799, result.Number);
            
        }
       
    }
        
}
