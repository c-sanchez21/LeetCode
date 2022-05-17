using System;
using System.Collections.Generic;

namespace _1091._Shortest_Path_in_Binary_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        int[][] dirs = { new int[] { -1, -1 }, new int[] { -1, 0 }, new int[] { -1, 1 }, 
            new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { 1, -1 }, new int[] { 1, 0 }, new int[] { 1, 1 } };

        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid == null) return -1;
            if (grid[0][0] != 0) return -1;
            int n = grid[0].Length;
            if (grid[n - 1][n - 1] != 0) return -1;

            Queue<int[]> q = new Queue<int[]>();
            grid[0][0] = 1;
            int[] cell;
            int row, col, dist;
            q.Enqueue(new int[] { 0, 0 });
            while (q.Count > 0)
            {
                cell = q.Dequeue();
                row = cell[0];
                col = cell[1];
                dist = grid[row][col];
                if (row == n - 1 && col == n - 1)
                    return dist;
                foreach (int[] neighbour in GetAdjacent(row, col, grid))
                {
                    int neighbourRow = neighbour[0];
                    int neighbourCol = neighbour[1];
                    q.Enqueue(new int[] { neighbourRow, neighbourCol });
                    grid[neighbourRow][neighbourCol] = dist + 1;
                }
            }
            return -1;
        }

            private List<int[]> GetAdjacent(int row, int col, int[][] grid)
            {
                List<int[]> neighbours = new List<int[]>();
                for (int i = 0; i < dirs.Length; i++)
                {
                    int newRow = row + dirs[i][0];
                    int newCol = col + dirs[i][1];
                    if (newRow < 0 || newCol < 0 || newRow >= grid.Length
                            || newCol >= grid[0].Length
                            || grid[newRow][newCol] != 0)
                    {
                        continue;
                    }
                    neighbours.Add(new int[] { newRow, newCol });
                }
                return neighbours;
            }
        }


    }
}
