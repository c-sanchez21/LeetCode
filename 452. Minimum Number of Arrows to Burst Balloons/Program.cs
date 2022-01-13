using System;
using System.Collections.Generic;

namespace _452._Minimum_Number_of_Arrows_to_Burst_Balloons
{
    class Program
    {
        //https://leetcode.com/problemset/all/
        static void Main(string[] args)
        {
            int[][] intervals1 = new int[][] {
                new int[2] {1,2 },
                new int[2] {3,4 },
                new int[2] {5,6 },
                new int[2] {7,8 } };
            Console.WriteLine(FindMinArrowShots(intervals1));
        }
        public static int FindMinArrowShots(int[][] points)
        {
            //Sort Points - by End Point
            Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));

            int[] interval = points[0];

            int end = interval[1]; //The first End
            int count = points.Length;//Number of Intervals

            int shots = 1; //Shots Required
            for (int i = 1; i < count; i++)
            {
                interval = points[i];
                if (end < interval[0]) //Interval does not overalp
                {
                    end = interval[1];//Update the new End
                    shots++;//Add Shot
                }
            }
            return shots;
        }
    }
}
