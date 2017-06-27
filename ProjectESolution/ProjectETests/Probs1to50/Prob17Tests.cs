/*
Number letter counts
Problem 17 
If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?


NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
The use of "and" when writing out numbers is in compliance with British usage.
*/
using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProjectEProbs._1to50;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Problem 17")]
    public class Prob17Tests
    {
        [Test]
        public void Test5()
        {
            int a = 1;
            int b = 5;
            int count = Prob17.GetLetterCount(a, b);
            string resultTxt = $"Lettercount for {a} thru {b} is: {count}";
            Utilities.TestUtils.WriteOut(resultTxt);
            Assert.AreEqual(19, count);
        }

        [Test]
        public void Test167()
        {
            int a = 1;
            int b = 167;
            int count = Prob17.GetLetterCount(a, b);
            string resultTxt = $"Lettercount for {a} thru {b} is: {count}";
            Utilities.TestUtils.WriteOut(resultTxt);
            Assert.AreEqual(2272, count);
        }

        [Test]
        public void Test1000()
        {
            int a = 1;
            int b = 1000;
            int count = Prob17.GetLetterCount(a, b);
            string resultTxt = $"Lettercount for {a} thru {b} is: {count}";
            Utilities.TestUtils.WriteOut(resultTxt);
            Assert.AreEqual(21124, count); //this is correct
        }
    }
}
