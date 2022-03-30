using System;

namespace _74._Search_a_2D_Matrix
{
    //https://leetcode.com/problems/search-a-2d-matrix/
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0) return false;
            int m = matrix.Length;
            if (matrix[0] == null || matrix[0].Length == 0) return false;
            int n = matrix[0].Length;

            int val = matrix[0][n - 1];
            int row = 1;
            while(row < m && val < target)
            {
                val = matrix[row][n - 1];
                row++;
            }
            if (row == m && val < target) return false;
            else row -= 1;
            for (int i = 0; i < n; i++)
                if (matrix[row][i] == target) return true;
            return false;


        }
    }
}
