/*
Maximum path sum I
Problem 18 
By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, 
is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs._1to50
{
    public static class Prob18
    {

        public static int GetMaxPathSum(FileInfo datafile)
        {
            List<string> lines = new List<string>(15);
            Utilities.ReadFileLines(datafile, s => lines.Add(s));
            //go bottom-up building a tree of TriangleNodes
            var root = BuildNodeStructure(lines);
            return root.MaxPathValue;
        }

        private static TriangleNode BuildNodeStructure(List<string> data)
        {
            TriangleNode[] lineBelow = LineToNodes(data.Last(), null);
            TriangleNode topNode = null;
            for (int lineIdx = data.Count() - 2; lineIdx >=0; lineIdx--)
            {
                TriangleNode[] thisLine = LineToNodes(data[lineIdx], lineBelow);
                if (lineIdx == 0)
                {
                    topNode = thisLine[0];
                }
                else
                {
                    lineBelow = thisLine;
                }
            }
            return topNode;
        }
        
        private static TriangleNode[] LineToNodes(string line, TriangleNode[] lineBelow = null)
        {
            int[] vals = ParseLine(line);
            TriangleNode[] newNodes = new TriangleNode[vals.Length];
            for(int i = 0; i < vals.Length; i++)
            {
                var left = lineBelow?[i];
                var right = lineBelow?[i + 1];
                newNodes[i] = new TriangleNode(vals[i], left, right);
            }
            return newNodes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int[] ParseLine(string line)
        {
            return line.Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        private class TriangleNode
        {
            public int Value { get; private set; }
            public TriangleNode LeftChild { get; private set; }
            public TriangleNode RightChild { get; private set; }
            public int MaxPathValue { get; private set; }
            
         
            public TriangleNode(int value, TriangleNode child1, TriangleNode child2)
            {
                Value = value;
                LeftChild = child1;
                RightChild = child2;

                int maxChildVal = 0;
                if (null != LeftChild && null != RightChild)
                {
                    maxChildVal = LeftChild.MaxPathValue > RightChild.MaxPathValue 
                        ? LeftChild.MaxPathValue : RightChild.MaxPathValue;
                }
                else
                {
                    maxChildVal = LeftChild?.MaxPathValue ?? RightChild?.MaxPathValue ?? 0;
                }
                MaxPathValue = Value + maxChildVal;
            }

            private static TriangleNode MaxOf(TriangleNode a, TriangleNode b)
            {
                if (null != a && null != b)
                    return a.Value > b.Value ? a : b;
                else
                    return a ?? b;
            }
        }
    }

    
}
