using System;
using System.Collections.Generic;

namespace Kth_Smallest_Element_in_a_Sorted_Matrix
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3805/
        static void Main(string[] args)
        {
            int[][] matrix = new int[][] { new int[] { 1, 5, 9 }, new int[] { 10, 11, 13 }, new int[] { 12, 13, 15 } };
            Console.WriteLine(KthSmallest(matrix, 8)); //Should be 13. 
        }

        public static int KthSmallest(int[][] matrix, int k)
        {
            //Flatten matrix into a list
            List<int> list = new List<int>();
            for(int i = 0; i < matrix.Length; i++)
                for(int j = 0; j < matrix[0].Length; j++)
                {
                    list.Add(matrix[i][j]);
                }

            //Sort the list
            list.Sort();

            //Return kth element
            return list[k - 1]; 
        }
    }
}
