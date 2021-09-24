using System;

namespace N_th_Tribonacci_Number
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/639/week-4-september-22nd-september-28th/3986/
        static void Main(string[] args)
        {
            for (int i = 0; i <= 37; i++)
                Console.WriteLine(Tribonacci(i));
        }

        public static int Tribonacci(int n)
        {
            //0 <= n <= 37;

            //Pre-Calculate values
            int[] A = new int[38];
            A[0] = 0;
            A[1] = 1;
            A[2] = 1;
            for (int i = 3; i <= 37; i++)
                A[i] = A[i - 1] + A[i - 2] + A[i - 3];

            //Return Pre-Calculated value. 
            return A[n];
        }
    }
}
