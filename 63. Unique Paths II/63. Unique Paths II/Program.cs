using System;

namespace _63._Unique_Paths_II
{
    //https://leetcode.com/problems/unique-paths-ii/
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static int m, n;
        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0) return 0;
            m = obstacleGrid.Length;
            n = obstacleGrid[0].Length;
            if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n-1] ==1) return 0; //Blocked
            int[,] cache = new int[m, n];
            return FindPaths(obstacleGrid, 0, 0, cache);
        }

        public static int FindPaths(int[][] grid, int i, int j, int[,] cache)
        {
            if (i < 0 || j < 0 || i >= m || j >= n) return 0;
            if (grid[i][j] == 1) return 0; //Obstacle
            if (i == m - 1 && j == n - 1) return 1;
            if (cache[i, j] != 0) return cache[i, j];
            //Can only move down or right
            cache[i, j] = FindPaths(grid, i + 1, j, cache) + FindPaths(grid, i, j + 1, cache);
            return cache[i, j];
        }
    }
}
