using System;
using System.Collections.Generic;

namespace _1288._Remove_Covered_Intervals
{
    class Program
    {
        //https://leetcode.com/problems/remove-covered-intervals/
        static void Main(string[] args)
        {
            //Example 1
            int[][] intervals1 = new int[][]
            {
                new int[] {1,4},new int[] {3,6},new int[] {2,8}
            };
            Console.WriteLine(RemoveCoveredIntervals(intervals1));

            //Example 2
            int[][] intervals2 = new int[][]
            {
                new int[] {1,4},new int[] {2,3}
            };
            Console.WriteLine(RemoveCoveredIntervals(intervals2));

            //Example 3
            int[][] intervals3 = new int[][]
            {
                new int[] {1,4},new int[] {1,5},new int[] {1,7}
            };
            Console.WriteLine(RemoveCoveredIntervals(intervals3));
        }

        public static int RemoveCoveredIntervals(int[][] intervals)
        {
            //Sort the intervals - first by start then by end (greater first)
            Array.Sort(intervals,
                new Comparison<int[]>((a, b) =>
                {
                    int compare = a[0].CompareTo(b[0]);
                    return compare == 0 ? b[1].CompareTo(a[1]) : compare;
                }));

            //Flatten the jagged array
            List<int[]> list = new List<int[]>(intervals.Length);
            foreach (int[] item in intervals)
                list.Add(item);

            //Remove redundant intervals
            for(int i = 0; i < list.Count-1;i++)
            {
                //If interval already covered then remove
                if (list[i][0] <= list[i + 1][0] &&
                    list[i][1] >= list[i + 1][1])
                {
                    list.RemoveAt(i + 1);
                    i--;
                }
            }
            //Return intervals remaining 
            return list.Count;
        }
    }
}
