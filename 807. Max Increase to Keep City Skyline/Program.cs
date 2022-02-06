using System;

namespace _807._Max_Increase_to_Keep_City_Skyline
{
    class Program
    {
        //https://leetcode.com/problems/max-increase-to-keep-city-skyline/
        static void Main(string[] args)
        {
            //Example 1:
            int[][] grid = new int[4][] {
                new int[] { 3, 0, 8, 4 }, 
                new int[] { 2, 4, 5, 7 }, 
                new int[] { 9, 2, 6, 3 }, 
                new int[] { 0, 3, 1, 0 } };
            Console.WriteLine(MaxIncreaseKeepingSkyline(grid));
        }

        //Refactored code to find the Max Increase
        //02/06/2022 13:42	Accepted	109 ms	37.8 MB csharp
        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            //Check for invlaid input 
            if (grid == null) return 0;

            int maxi = grid.GetLength(0);
            int maxj = grid[0].GetLength(0);

            //Survey the grid for the Max Values in each row and column
            int[] maxRows = new int[maxi];
            int[] maxCols = new int[maxj];
            int val = 0;
            for (int i = 0; i < maxi; i++)
                for (int j = 0; j < maxj; j++)
                {
                    val = grid[i][j];
                    maxRows[i] = Math.Max(maxRows[i], val);
                    maxCols[j] = Math.Max(maxCols[j], val);
                }

            //Find the Max Increase with affecting skyline
            int inc = 0;
            for (int i = 0; i < maxi; i++)
                for (int j = 0; j < maxj; j++) 
                    //Takes the lesser value of maxRow i and maxCol j as to not affect the skyline in either direction
                    inc += Math.Min(maxRows[i], maxCols[j]) - grid[i][j];
            
            //Return the result
            return inc;
        }


        //Older Code 
        //Note: 2022-02-06 this code got 100% faster rating than all submissions...? 
        //02/06/2022 13:41	Accepted	76 ms	40.2 MB csharp
        [Obsolete]
        public static int MaxIncreaseKeepingSkylineOld(int[][] grid)
        {
            int maxi = grid.GetLength(0);
            int maxj = grid[0].GetLength(0);
            int count = 0;
            for (int i = 0; i < maxi; i++)
            {
                for (int j = 0; j < maxj; j++)
                {
                    int x = j;
                    int y = 0;
                    int maxVal = 0;

                    //Check Column
                    for (; y < maxi; y++)
                        if (maxVal < grid[y][x])
                            maxVal = grid[y][x];

                    //Check Row
                    x = 0;
                    y = i;
                    int maxVal2 = 0;
                    for (; x < maxj; x++)
                        if (maxVal2 < grid[y][x])
                            maxVal2 = grid[y][x];

                    //Lesser of two values
                    maxVal = maxVal > maxVal2 ? maxVal2 : maxVal;
                    int val = grid[i][j];

                    if (val < maxVal)
                        count += maxVal - val;
                }
            }
            return count;
        }
    }
}
