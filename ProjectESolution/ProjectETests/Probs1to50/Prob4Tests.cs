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
    [Category("Prob4Tests")]
    public class Prob4Tests
    {
        [Test]
        public void PalindromeGenerator()
        {
            int n = 1000;
            var pals = Prob4.PalindromesAtOrBelow(1000).ToArray();
            string s = $"Palindromes <= {n} are {String.Join(",", pals)}";
            TestUtils.WriteOut(s);
           
            Assert.IsTrue(pals.Length > 0);
        }

        [Test]
        public void TestFor2Digits()
        {
            var result = Prob4.LargestPalindromeProduct(2);

            Assert.IsTrue(result == 9009);
        }
        
        [Test]
        public void TestFor3Digits()
        {
            var result = Prob4.LargestPalindromeProduct(3);
            TestUtils.WriteOut($"Largest palindrome product with 2 3-digit factors is {result}.");
            //906609
            Assert.IsTrue(result == 906609);
        }
    }
}
