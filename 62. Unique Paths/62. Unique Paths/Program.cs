using System;

namespace _62._Unique_Paths
{
    //https://leetcode.com/problems/unique-paths/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UniquePaths(3, 7));//28
            Console.WriteLine(UniquePaths(3, 2));//3
            Console.WriteLine(UniquePaths(7, 3));//28
            Console.WriteLine(UniquePaths(3, 3));//6
        }

        public static int UniquePaths(int m, int n)
        {
            //Initialize Array
            int[,] arr = new int[m, n];
            int i, j;
            //Fill first column to zero
            for (i = j = 0; i < n; i++)
                arr[0, i] = 1;
            //Fill first row to zero
            for (i = j = 0; j < m; j++)
                arr[j, 0] = 1;

            //Calculate number of paths
            for(j = 1; j < m; j++)
                for(i = 1; i < n; i++)
                    arr[j, i] = arr[j - 1, i] + arr[j, i - 1];

            //Return solution\
            return arr[m - 1, n - 1];
        }
    }
}
