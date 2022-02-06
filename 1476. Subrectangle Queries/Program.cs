using System;
using System.Linq;

namespace _1476._Subrectangle_Queries
{
    class Program
    {
        //https://leetcode.com/problems/subrectangle-queries/
        static void Main(string[] args) { }

        public class SubrectangleQueries
        {
            private int[][] rect;
            public SubrectangleQueries(int[][] rectangle)
            {
                //Copy Array
                rect = rectangle.Select(r => r.ToArray()).ToArray();
            }

            public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
            {
                //Update the specified sub rectangle with new value
                for (int i = row1; i <= row2; i++)
                    for (int j = col1; j <= col2; j++)
                        rect[i][j] = newValue;
            }

            public int GetValue(int row, int col)
            {
                return rect[row][col];
            }
        }
    }
}
