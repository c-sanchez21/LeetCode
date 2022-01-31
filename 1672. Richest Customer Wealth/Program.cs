using System;

namespace _1672._Richest_Customer_Wealth
{
    class Program
    {
        //https://leetcode.com/problems/richest-customer-wealth/
        static void Main(string[] args)
        {
            //Example 1
            int[][] accounts1 = new int[][]
            {
                new int[] {1,2,3 },
                new int[] {3,2,1 }
            };
            Console.WriteLine(MaximumWealth(accounts1));

            //Example 2
            int[][] accounts2 = new int[][]
            {
                new int[] {1,5 },
                new int[] {7,3 },
                new int[] {3,5 }
            };
            Console.WriteLine(MaximumWealth(accounts2));
        }

        public static int MaximumWealth(int[][] accounts)
        {
            int max = 0;
            int sum;
            //Iterate thru all the rows and colums
            for(int i =0; i < accounts.Length; i++)
            {
                //Find sum
                sum = 0;
                for (int j = 0; j < accounts[i].Length; j++)
                    sum += accounts[i][j];
                max = Math.Max(sum, max); //Take the max value
            }
            return max; //Return max
        }
    }
}
