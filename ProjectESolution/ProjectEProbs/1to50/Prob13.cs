/*
Large sum
Problem 13 
Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
[file data/Prob13Data.txt]
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob13
    {
        public static long First10DigitsOfSum()
        {
            List<string> data = LoadDataFile();
            var sum = data.Select(s => long.Parse(s.Substring(0, 12))).Sum();
            string tmp = sum.ToString().Substring(0, 10);
            return long.Parse(tmp);
        }

        private static List<string> LoadDataFile()
        {
            var binDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string p = Path.Combine(binDir, @"Data\Prob13Data.txt");
            FileInfo file = new FileInfo(p);
            if (!file.Exists)
            {
                throw new FileNotFoundException(p);
            }

            List<string> nums = new List<string>(100);
            Utilities.ReadFileLines(file, s => nums.Add(s));
            return nums;
        }

        
    }
}
