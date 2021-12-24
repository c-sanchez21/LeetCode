using System;
using System.Collections.Generic;

namespace _56._Merge_Intervals
{
    //https://leetcode.com/problems/merge-intervals/
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals1 = new int[][]
            {
                new int[2] {1,3 },
                new int[2] {2,6 },
                new int[2] {8,10 },
                new int[2] {15,18 }
            };
            PrintArray(Merge(intervals1));
            int[][] intervals2 = new int[][]
            {
                new int[2] {1,4 },
                new int[2] {4,5 }
            };
            PrintArray(Merge(intervals2));

            int[][] intervals3 = new int[][]
            {
                new int[2] {1,4},
                new int[2] {0,2},
                new int[2] {3,5}
            };
            PrintArray(Merge(intervals3));

        }

        public static void PrintArray(int[][] array)
        {
            Console.Write("[ ");
            foreach(int[] interval in array)
                Console.Write("[{0},{1}] ",interval[0],interval[1]);
            Console.WriteLine(" ]");
        }

        public static int[][] Merge(int[][] intervals)
        {
            //Sort Intervals 
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> results = new List<int[]>();//Hols results

            //Add the first interval to our results
            results.Add(intervals[0]);
            int end = intervals[0][1]; //The first End
            int count = intervals.Length;//Number of Intervals
            
            int[] interval;//Current Interval
            for(int i = 1; i < count; i++)
            {
                interval = intervals[i];
                if (end < interval[0]) //Interval does not overalp
                {
                    results.Add(interval);//Add the interval
                    end = interval[1];//Update the new End
                }
                else //Overlap exists
                {
                    end = Math.Max(end, interval[1]);//Take latest end
                    results[results.Count - 1][1] = end;//Update end 
                }
            }
            return results.ToArray();//Return results
        }
    }
}
