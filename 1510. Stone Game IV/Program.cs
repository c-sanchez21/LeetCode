using System;

namespace _1510._Stone_Game_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
                Console.WriteLine("N={0} => {1}", i, WinnerSquareGame(i));
                
        }

        public static bool WinnerSquareGame(int n)
        {
            bool[] dp = new bool[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int k = 1; k * k <= i; k++)
                {
                    if (dp[i - k * k] == false)
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[n];
        }
    }
}
