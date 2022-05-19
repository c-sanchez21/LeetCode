using System;

namespace _329._Longest_Increasing_Path_in_a_Matrix
{
    internal class Program
    {
        //https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
        static void Main(string[] args)
        {

        }

        private static int[][] dirs = { new int[] { 0, 1 }, new int[] { 1, 0 },
            new int[] { 0, -1 }, new int[] { -1, 0 } };
        private static int m, n;
        public static int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;
            m = matrix.Length;
            n = matrix[0].Length;
            int[,] cache = new int[m,n];
            int ans = 0;
            for(int i= 0; i < m; i++)
                for(int j = 0; j < n; j++)
                {
                    ans = Math.Max(ans, DFS(matrix, i, j,cache));
                }
            return ans;
        }

        //Naive DFS - Time Exceeded O(2^[m+n]) complexity. 
        //Space Complexity = O(mn)
        private static int DFSNaive(int[][] matrix, int i, int j)
        {
            int ans = 0;
            foreach (int[] d in dirs) //For each direction
            {
                int x = i + d[0];
                int y = j + d[1];
                if (x >= 0 && x < m && y >= 0 && y < n //Check if out of bounds
                    && matrix[x][y] > matrix[i][j]) //Check if path is increasing
                {
                    ans = Math.Max(ans, DFSNaive(matrix, x, y));
                }
            }
            return ++ans;

        }

        //DFS - With Memoization O(m^2*n^2)
        private static int DFS(int[][] matrix, int i, int j, int[,] cache)
        {
            if (cache[i, j] != 0) return cache[i, j];
            foreach (int[] d in dirs) //For each direction
            {
                int x = i + d[0];
                int y = j + d[1];
                if (x >= 0 && x < m && y >= 0 && y < n //Check if out of bounds
                    && matrix[x][y] > matrix[i][j]) //Check if path is increasing
                {
                    cache[i,j] = Math.Max(cache[i,j], DFS(matrix, x, y,cache));
                }
            }
            return ++cache[i, j];
        }


    }
}
