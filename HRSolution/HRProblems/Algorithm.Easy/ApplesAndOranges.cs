using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProblems.Algorithm.Easy
{
    public class ApplesAndOranges : IProblem
    {
        public string Run()
        {
            int s = 7;// 2;
            int t = 11;// 3;
            int a = 5;// 1;
            int b = 15;// 5;
            int[] apples = { -2, 2, 1 };//{ 2 };
            int[] oranges = {5, -6 };//{ -2 };
            countApplesAndOranges(s, t, a, b, apples, oranges);
            return String.Empty;
        }

        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int houseLen = t - s;
            //these are DISTANCE ranges, not absolute range. distance from respective tree.
            int[] appleRange = Enumerable.Range(s - a, houseLen + 1).ToArray();
            int[] orangeRange = Enumerable.Range(s - b, houseLen + 1).ToArray();

            int appleStart = s - a;
            int appleEnd = appleStart + houseLen;

            int orangeStart = s - b;
            int orangeEnd = orangeStart + houseLen;

            int appleHits = apples.Count(ap => ap >= appleStart && ap <= appleEnd);
            int orangeHits = oranges.Count(org => org >= orangeStart && org <= orangeEnd);

            Console.WriteLine(appleHits);
            Console.WriteLine(orangeHits);
            
        }
    }
}
