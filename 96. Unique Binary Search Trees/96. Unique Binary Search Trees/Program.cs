using System;

namespace _96._Unique_Binary_Search_Trees
{
    class Program
    {
        //https://leetcode.com/problems/unique-binary-search-trees/
        static void Main(string[] args)
        {
            for (int i = 1; i <= 19; i++)
                Console.WriteLine("G[{0}] = {1}", i, NumTrees(i));
        }

        public static int NumTrees(int n)
        {
            if (n < 0) return 0;
            int[] G = new int[n + 1];
            G[0] = 1;
            G[1] = 1;

            //Calculate values starting from 2,...
            for (int i = 2; i <= n; i++)
            {
                //Sum the values from 1 to i 
                for (int j = 1; j <= i; j++)
                {
                    G[i] += G[j - 1] * G[i - j];
                }
            }
            return G[n];
        }
    }

}
