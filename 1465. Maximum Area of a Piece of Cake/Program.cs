using System;

namespace _1465._Maximum_Area_of_a_Piece_of_Cake
{
    //https://leetcode.com/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxArea(5, 4, new int[] { 1, 2, 4 }, new int[] { 1, 3 }));
            Console.WriteLine(MaxArea(5, 4, new int[] { 3,1 }, new int[] { 1}));
        }

        public static int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            int n = horizontalCuts.Length;
            int m = verticalCuts.Length;

            long maxHeight = Math.Max(horizontalCuts[0],h- 
                horizontalCuts[n - 1]);
            for (int i = 1; i < n; i++)
            {
                maxHeight = Math.Max(maxHeight, horizontalCuts[i]
                    - horizontalCuts[i - 1]);
            }

            long maxWidth = Math.Max(verticalCuts[0], w - verticalCuts[m - 1]);
            for (int i = 1; i < m; i++)
            {
                maxWidth = Math.Max(maxWidth, verticalCuts[i] - verticalCuts[i - 1]);
            }

            return (int)((maxWidth * maxHeight) % (1000000007));
    
        }
    }
}
