using System;
using System.Collections.Generic;

namespace Largest_Plus_Sign
{
    //https://leetcode.com/problems/largest-plus-sign/solution/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Largest Plus Sign");
        }

        public static int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            HashSet<int> mineCells = new HashSet<int>();
            
            //Flatten Mine Grid
            foreach(int[] mine in mines)
                mineCells.Add(mine[0] * n + mine[1]);

            int ans = 0;
            int count;
            int[,] scores = new int[n, n];

            //Row by Row - Top to bottom
            for(int y = 0; y < n; ++y)
            {

                //Left to right
                count = 0;
                for (int x = 0; x < n; ++x)
                {
                    count = mineCells.Contains(y * n + x) ? 0 : count + 1;
                    scores[y, x] = count;
                }
                //Right to left
                count = 0;
                for(int x = n-1; x >= 0; --x)
                {
                    count = mineCells.Contains(y * n + x) ? 0 : count + 1;
                    scores[y, x] = Math.Min(scores[y,x], count);
                }
            }

            //Column by Column - Left to right 
            for(int x = 0; x < n; ++x)
            {

                //Top to bottom
                count = 0;
                for (int y = 0; y < n; ++y)
                {
                    count = mineCells.Contains(y * n + x) ? 0 : count + 1;
                    scores[y, x] = Math.Min(scores[y, x], count);
                }

                //Bottom to Top
                count = 0;
                for(int y = n-1; y >= 0; --y)
                {
                    count = mineCells.Contains(y * n + x) ? 0 : count + 1;
                    scores[y, x] = Math.Min(scores[y, x], count);
                    ans = Math.Max(ans, scores[y, x]);
                }
            }
            return ans;
        }
    }
}
