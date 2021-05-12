using System;

namespace Range_Sum_Query_2D___Immutable
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3740/
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class NumMatrix
        {

            int[][] matrix; 
            public NumMatrix(int[][] matrix)
            {
                this.matrix = matrix;
            }

            /// <summary>
            /// Sums the specified region of the Matrix
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="col1"></param>
            /// <param name="row2"></param>
            /// <param name="col2"></param>
            /// <returns></returns>
            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                if (matrix == null || matrix.Length == 0) return 0;
                int sum = 0; 
                for(int i = row1; i <= row2; i++)
                {
                    for(int j = col1; j <= col2; j++)
                    {
                        sum += matrix[i][j];
                    }
                }
                return sum; 
            }
        }

    }
}
