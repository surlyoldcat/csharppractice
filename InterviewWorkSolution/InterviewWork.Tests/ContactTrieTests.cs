using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace InterviewWork.Tests
{
    [TestClass]
    public class ContactTrieTests
    {
        [TestMethod]
        public void AddTest()
        {
            ContactTrie ct = new ContactTrie();
            ct.Add("fooby");
            ct.Add("cran");
            ct.Add("gel");
            ct.Add("gronk");
            ct.Add("geekboy");
            ct.Add("foobytwo");
            ct.Print();

            

        }

        [TestMethod]
        public void FindTestSearTermTooLong()
        {
            var wordlist = CreateWordList(100, 4);
            ContactTrie ct = new ContactTrie();
            foreach (string word in wordlist)
            {
                ct.Add(word);
            }
            
            var result = ct.Find("alongerstring");
            Assert.IsTrue(result.Count == 0);

        }

        [TestMethod]
        public void FindTestLargeSample()
        {
            var wordlist = CreateWordList(100000, 8);
            ContactTrie ct = new ContactTrie();
            foreach(string word in wordlist)
            {
                ct.Add(word);
            }
            ct.Add("egbert");

            var result = ct.Find("eg");
            Assert.IsTrue(result.Count > 0);


            
        }

        [TestMethod]
        public void FindTestEmptySearchTerm()
        {
            ContactTrie ct = CreateTestTrie();
            var result = ct.Find(String.Empty);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FindTestNullSearchTerm()
        {
            ContactTrie ct = CreateTestTrie();
            var result = ct.Find(null);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FindTestNullList()
        {
            ContactTrie ct = new ContactTrie();
            var result = ct.Find("gu");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindTest1()
        {
            ContactTrie ct = CreateTestTrie();

            var result = ct.Find("guitar");
            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void FindTest2()
        {
            ContactTrie ct = CreateTestTrie();
            var result = ct.Find("gu");
            Assert.IsTrue(result.Count == 3);
        }

        static ContactTrie CreateTestTrie()
        {
            ContactTrie ct = new ContactTrie();
            ct.Add("guitar");
            ct.Add("git");
            ct.Add("guild");
            ct.Add("borscht");
            ct.Add("guitarworld");
            return ct;
        }

        static readonly char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        static List<string> CreateWordList(int numwords, int wordMaxLength)
        {
            Random rand = new Random();
            var words = new List<string>(numwords);
            for(int i = 0;i< numwords;i++)
            {
                int wordlength = rand.Next(2, wordMaxLength);
                words.Add(CreateWord(wordlength));
            }
            return words;
        }

        static string CreateWord(int length)
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int idx = rand.Next(characters.Length - 1);
                sb.Append(characters[idx]);
            }
            return sb.ToString();
        }
    }
}
