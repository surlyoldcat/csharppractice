using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFBD.Arr
{
    internal class TransformerTests
    {
        public void RunTests()
        {
            //some vanilla test cases
            TestAString(String.Empty, String.Empty, "Testing empty string");
            TestAString("ABC123", "321cbA", "Testing ABC123");
            TestAString("It was the best of times LOL.", ".lOl sEmIt fO tsEb Eht sAw tI", "Testing some english babble");
            TestAString("G B ee #*@#))@", "@))#@*# EE b g", "Testing some gibberish");
            
            // create a pseudo-random string 100k characters long and try that
            char[] characters = "_*%#!) =abcdefghijklmnopABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            char[] vowels = "aeiouy".ToCharArray();
            int bigStringLength = 100000;
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bigStringLength; i++)
            {
                int idx = rand.Next(characters.Length - 1);
                sb.Append(characters[idx]);
            }
            string bigString = sb.ToString();

            // do the transform the hard way, to verify the fancy Linq expression
            // (i know this is ugly. i'm trying to build the transformed string in
            // a different, more simplerer fashion, that's all)
            char[] reversed = bigString.Reverse().ToArray();
            for (int a = 0;a < reversed.Length; a++)
            {
                char lowered = Char.ToLowerInvariant(reversed[a]);
                reversed[a] = vowels.Contains(lowered)
                    ? Char.ToUpperInvariant(lowered)
                    : lowered;                
            }
            string expected = new string(reversed);
            TestAString(bigString, expected, "Testing a pretty long (100K chars) randomish string");

        }

        private void TestAString(string test, string expected, string msg)
        {
            // show the 'testing' message, run the transform, compare
            // expected vs actual, throw an exception if it fails. just
            // simulating a very simple unit test framework.
            Console.WriteLine(msg);            
            char[] resultArr = Transformer.Transform(test.ToCharArray());
            string result = new string(resultArr);
            if (!result.Equals(expected, StringComparison.CurrentCulture))
            {
                throw new ApplicationException("Expected did not match actual. You have failed.");
            }
            Console.WriteLine("Passed.");
        }
        
    }
}
