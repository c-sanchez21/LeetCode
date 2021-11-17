using System;

namespace _62._Unique_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UniquePaths(3, 7));
            Console.WriteLine(UniquePaths(3, 2));
            Console.WriteLine(UniquePaths(7, 3));
            Console.WriteLine(UniquePaths(3, 3));
        }

        public static int UniquePaths(int m, int n)
        {
            int[,] arr = new int[m, n];
            int i, j;
            for (i = j = 0; i < n; i++)
                arr[0, i] = 1;
            for (i = j = 0; j < m; j++)
                arr[j, 0] = 1;

            for(j = 1; j < m; j++)
                for(i = 1; i < n; i++)
                    arr[j, i] = arr[j - 1, i] + arr[j, i - 1];

            return arr[m - 1, n - 1];
        }
    }
}
