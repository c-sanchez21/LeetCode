using System;

namespace Search2DMatrix
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3650/
        static void Main(string[] args)
        {
            int[][] matrix = new int[][]
            {
                new int[] { 1, 4, 7, 11, 15 },
                new int[] { 2, 5, 8, 12, 19 },
                new int[] { 3, 6, 9, 16, 22 },
                new int[] {10, 13, 14, 17, 24 },
                new int[] {18, 21, 23, 26, 30 }
            };
            Console.WriteLine(SearchMatrix(matrix, 5));
            Console.WriteLine(SearchMatrix(matrix, 20));
        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length; //Rows
            int n = matrix[0].Length; //Columns
            int i = 0;
            int j = n - 1; //Start top right
            while(i < m && j >= 0)
            {
                if (matrix[i][j] == target) return true;

                if (matrix[i][j] < target)
                    i++;
                else j--;
            }
            return false;
        }
    }
}
