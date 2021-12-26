using System;
using System.Collections.Generic;

namespace _973._K_Closest_Points_to_Origin
{
    class Program
    {
        //https://leetcode.com/problems/k-closest-points-to-origin/
        static void Main(string[] args)
        {
            //Example 1
            int[][] points1 = new int[][]
            {
                new int[2] {1,3 },
                new int[2] {-2,2}
            };
            PrintPoints(KClosest(points1,1));

            //Example 2
            int[][] points2 = new int[][]
            {
                new int[2] {3,3},
                new int[2] {5,-1 },
                new int[2] {-2,4 }
            };
            PrintPoints(KClosest(points2, 2));
        }

        private static void PrintPoints(int[][] points)
        {
            Console.Write("[ ");
            foreach(int[] point in points)
            {
                Console.Write("[{0},{1}] ", point[0], point[1]);
            }
            Console.WriteLine("]");
        }

        public static int[][] KClosest(int[][] points, int K)
        {
            List<int[]> pointsToSort = new List<int[]>(); //List of Points
            
            //Add all points to the list
            foreach (int[] point in points)
                pointsToSort.Add(point);
            
            //Sort the points using custom comparer
            pointsToSort.Sort(new CustomPointCompare());

            //Return Range of K-Items
            return pointsToSort.GetRange(0,K).ToArray();
        }
        public class CustomPointCompare : IComparer<int[]>
        {
            public int Compare(int[] p1, int[] p2)
            {
                double d1 = Math.Pow(p1[0], 2) + Math.Pow(p1[1], 2);
                double d2 = Math.Pow(p2[0], 2) + Math.Pow(p2[1], 2);
                return d1.CompareTo(d2);
            }
        }
    }
}
