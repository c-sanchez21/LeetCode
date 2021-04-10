using System;

namespace Longest_Increasing_Path_in_a_Matrix
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3703/
        static void Main(string[] args)
        {
            int[][] matrix1 = { new int[] { 9, 9, 4 }, new int[] { 6, 6, 8 }, new int[] { 2, 1, 1 } };
            Console.WriteLine(LongestIncreasingPath(matrix1));
        }

        static int m, n; //Matrix size 
        public static int LongestIncreasingPath(int[][] matrix)
        {
            //Base Case
            if (matrix == null || matrix.Length == 0) return 0;
            
            //Get Matrix Size 
            m = matrix.Length;
            n = matrix[0].Length;
            
            //Initialize Cache for Memoization
            int[,] cache = new int[m, n];

            //Find Longest Increasing path along the Matrix
            int longest = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    longest = Math.Max(longest, DFS(matrix, i, j, cache));
            return longest;
        }
        //Each possible direction
        static int[][] dirs = new int[][] { new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] {-1, 0 } };
        
        //Depth First Search
        public static int DFS(int[][] matrix, int i , int j, int[,] cache)
        {
            //Use cache first if available
            if (cache[i, j] != 0) return cache[i, j];
            
            //For each direction
            foreach(int[] d in dirs)
            {
                int x = i + d[0];
                int y = j + d[1];
                //If within bounds then explore the path
                if (x >= 0 && y >= 0 && x < m && y < n && matrix[x][y] > matrix[i][j])
                    cache[i,j] = Math.Max(cache[i,j], DFS(matrix, x, y, cache));//Take greater of two
            }
            return (++cache[i, j]);
        }
    }
}
