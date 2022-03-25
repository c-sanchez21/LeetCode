using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1029._Two_City_Scheduling
{
    //https://leetcode.com/problems/two-city-scheduling/
    class Program
    {
        static void Main(string[] args)
        {
            //Examples
            int[][] input1 = { new int[] { 10, 20 }, new int[] { 30, 200 },
            new int[]{400,50 },new int[]{30,20 } };

            int[][] input2 = { new int[] { 259, 770 }, new int[] { 448, 54 },
            new int[]{926,667 },new int[]{184,139 },new int[]{840,118 },
            new int[]{577,469} };

            int[][] input3 = { new int[] { 515, 563 }, new int[] { 451, 713 },
            new int[]{537,709 },new int[]{343,819 }, new int[] {855,779 },
            new int[]{457,60 }, new int[]{650,359 }, new int[] {631,42 } };

            Console.WriteLine(TwoCitySchedCost(input1));
            Console.WriteLine(TwoCitySchedCost(input2));
            Console.WriteLine(TwoCitySchedCost(input3));
        }

        public class CustomPairCompare : IComparer<int[]>
        {
            public int Compare(int[] p1, int[] p2)
            {
                int diff1 = Math.Abs(p1[0] - p1[1]);
                int diff2 = Math.Abs(p2[0] - p2[1]);
                return diff1.CompareTo(diff2);
            }
        }

        public static int TwoCitySchedCost(int[][] costs)
        {
            List<int[]> list = new List<int[]>(costs);

            //Sort by difference in price (CityA vs CityB)
            list.Sort(new CustomPairCompare());
            list.Reverse();
            int half = costs.Length/2;
            int a = half; //Half go to A
            int b = half; //Half go to B
            int idx = 0;
            int sum = 0;
            int[] pair; 

            //Take cheapest city while still being able to
            //meet half & half criteria
            while (a > 0 && b > 0)
            {
                pair = list[idx++];
                if(pair[0] <= pair[1])
                {
                    a--;
                    sum += pair[0];
                }
                else
                {
                    b--;
                    sum += pair[1];
                }
            }

            //Take whatever city needed to meet half & half criteria
            while( a > 0)
            {
                pair = list[idx++];
                sum += pair[0];
                a--;
            }
            while(b > 0)
            {
                pair = list[idx++];
                sum += pair[1];
                b--;
            }

            return sum;
        }

        /*
        const intArrayStr = @"[[\d+,\d+]]";
        static int[][] GetIntArray(string s)
        {
            Regex rx = new Regex(int )
        }
        */
    }
}
