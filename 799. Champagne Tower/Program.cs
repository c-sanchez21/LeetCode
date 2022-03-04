using System;

namespace _799._Champagne_Tower
{
    class Program
    {
        //https://leetcode.com/problems/champagne-tower/solution/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(ChampagneTower(1, 1, 1));
            Console.WriteLine(ChampagneTower(2, 1, 1));
            Console.WriteLine(ChampagneTower(3, 1, 1));
            Console.WriteLine(ChampagneTower(4, 2, 0));
            Console.WriteLine(ChampagneTower(4, 2, 1));
            Console.WriteLine(ChampagneTower(4, 2, 2));
        }

        public static double ChampagneTower(int poured, int query_row, int query_glass)
        {
            //Check for invalid input
            if (poured <= 0) return 0;

            int maxSize = 100; //Max size as defined by problem

            //Initialize variables
            double[,] matrix = new double[maxSize+1, maxSize+1];
            matrix[0, 0] = poured; //Pour all into first glass
            double toPour;

            //Iterate thru all cells
            for(int j = 0; j < maxSize; j++)
                for(int i = 0; i < maxSize; i++)
                {
                    //If cell has excess
                    if (matrix[j, i] > 1) 
                    {
                        //Divide by half and distribute to left and right evenly
                        toPour = ((matrix[j, i] - 1) / 2.0);
                        matrix[j + 1, i] += toPour;//Left
                        matrix[j + 1, i + 1] += toPour;//Right
                        matrix[j, i] = 1; //Remove excess
                    }
                    //If cell to query reached then break and return value
                    if(query_row == j && query_glass == i)
                        return matrix[j, i];
                }

            //Fail safe return value
            return matrix[query_row, query_glass];
        }
    }
}
