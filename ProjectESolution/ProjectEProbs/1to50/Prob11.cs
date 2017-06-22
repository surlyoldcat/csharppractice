/*
Largest product in a grid
Problem 11 
In the 20×20 grid below, four numbers along a diagonal line have been marked in red.

08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48

The product of these numbers is 26 × 63 × 78 × 14 = 1788696.

What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob11
    {
        private static readonly byte[] Grid;
        private static readonly int NumRows = 20;
        private static readonly int NumCols = 20;
        static Prob11()
        {
            string txt = @"08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
            string splitup = Regex.Replace(txt, @"\s+", ",");
            Grid = splitup.Split(',').Select(s => byte.Parse(s)).ToArray();
            Debug.Assert(Grid.Length == NumRows * NumCols);
            //string eold = Regex.Replace(txt, "[\r\n]+", "EOL");

            //string[] splitintolines = eold.Split("EOL".ToArray());
            //System.Diagnostics.Debug.Assert(splitintolines.Length == 20);
            //for(int r = 0; r < splitintolines.Length; r++)
            //{
            //    string[] splitintocols = splitintolines[r].Split(' ');
            //    System.Diagnostics.Debug.Assert(splitintocols.Length == 20);
            //    for (int c = 0; c < splitintocols.Length; c++)
            //    {
            //        Grid[r, c] = byte.Parse(splitintocols[c]);
            //    }
            //}
        }

        public static long Solve()
        {
            // going top-down, left-to-right; for diagonals, have to
            //check down and right, and down and left, for each item
            //in the grid array; since we know the dimensions of the
            // grid (20x20) we can just use index math to naviagate, 
            //instead of using a multi-D array
            
            
            var downs = IndicesForDown();
            var maxFromDowns = downs.Select(d => DownProduct(d)).Max();

            var acrosses = IndicesForAcross();
            var maxFromAcross = acrosses.Select(a => AcrossProduct(a)).Max();

            var downrights = IndicesForDownRight();
            var maxFromDownRight = downrights.Select(dr => DownRightProduct(dr)).Max();

            var downlefts = IndicesForDownLeft();
            var maxFromDownLeft = downlefts.Select(dl => DownLeftProduct(dl)).Max();

            long[] maxes = { maxFromAcross, maxFromDowns, maxFromDownLeft, maxFromDownRight };

            return maxes.Max();
        }

        private static IEnumerable<int> IndicesForDown()
        {
            //last index for downs should be 319
            for (int i = 0; i < NumCols; i++)
            {
                var indices = Utilities.GenerateSequence(i, 16, 20);
                var x = indices.First();
                var y = indices.Last();
                foreach (int index in indices)
                {
                    Debug.Assert(index < Grid.Length);
                    yield return index;
                }
            }
        
        }

        private static long AcrossProduct(int index)
        {
            //iterate by 1's
            long[] vals = { 0, 0, 0, 0 };
            for (int a = 0; a < 4; a++)
            {
                int b = index + a;
                vals[a] = (long)Grid[b];
            }
            long product = vals.Aggregate(1, (long acc, long i) => acc * i);
            return product;
        }

        private static long DownProduct(int index)
        {
            //iterate by 20's
            //0, 20, 40... 1, 21, 41, 61.... 7, 27, 47, ....
            long[] vals = { 0, 0, 0, 0 };
            for (int a = 0; a < 4; a++)
            {
                int b = index + 20 * a;
                vals[a] = (long)Grid[b];
            }
            long product = vals.Aggregate(1, (long acc, long i) => acc * i);
            return product;
        }

        private static long DownRightProduct(int index)
        {
            //iterate by 21's
            long[] vals = { 0, 0, 0, 0 };
            for (int a = 0; a < 4; a++)
            {
                int b = index + 21 * a;
                vals[a] = (long)Grid[b];
            }
            long product = vals.Aggregate(1, (long acc, long i) => acc * i);
            return product;
        }

        private static long DownLeftProduct(int index)
        {
            //iterate by 19's
            long[] vals = { 0, 0, 0, 0 };
            for (int a = 0; a < 4; a++)
            {
                int b = index + 19 * a;
                vals[a] = (long)Grid[b];
            }
            long product = vals.Aggregate(1, (long acc, long i) => acc * i);
            return product;
        }
        private static IEnumerable<int> IndicesForAcross()
        {
            for (int i = 0; i < NumRows; i++)
            {
                var indices = Enumerable.Range(i * NumCols, 17);
                foreach (int index in indices)
                {
                    Debug.Assert(index < Grid.Length);
                    yield return index;
                }
            }
        }

        private static IEnumerable<int> IndicesForDownRight()
        {
            //this is just the intersection of Down and Across indices
            var a = IndicesForAcross();
            var d = IndicesForDown();
            var intersection = a.Intersect(d);
            foreach (int index in intersection)
            {
                Debug.Assert(index < Grid.Length);
                yield return index;
            }

        }
       
        private static IEnumerable<int> IndicesForDownLeft()
        {
            //intersection of Down indices and the grid without the first 4 columns
            List<int> acrosses = new List<int>(320);
            for (int i = 0; i < NumRows; i++)
            {
                acrosses.AddRange(Enumerable.Range(i * NumCols + 3, 17));
            }
            var downs = IndicesForDown();
            var intersection = acrosses.Intersect(downs);
            foreach (int index in intersection)
            {
                Debug.Assert(index < Grid.Length);
                yield return index;
            }

        }

        private class Quadruplet
        {
            public byte[] Values { get; private set; }

            public Quadruplet(byte[] vals)
            {
                Values = vals;
            }

            public long Product()
            {
                long seed = 1;
                return Values.Cast<long>().Aggregate(seed, (acc, x) => acc * x);
            }
        }
    }
}
