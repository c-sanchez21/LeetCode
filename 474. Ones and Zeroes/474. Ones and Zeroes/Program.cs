using System;

namespace _474._Ones_and_Zeroes
{
    internal class Program
    {
        //https://leetcode.com/problems/ones-and-zeroes/
        static void Main(string[] args)
        {
            string[] input = new string[] { "10", "0001", "111001", "1", "0" };

            Console.WriteLine(FindMaxForm(input, 5, 3));
        }

        public static int FindMaxForm(string[] strs, int m, int n)
        {
            int[,] dp = new int[m + 1,n + 1];
            foreach(string s in strs)
            {
                int[] count = CountZeroesOnes(s);
                for (int z = m; z >= count[0]; z--)
                    for (int ones = n; ones >= count[1]; ones--)
                        dp[z, ones] = Math.Max(1 + dp[z - count[0],
                            ones - count[1]], dp[z, ones]);
              
            }
            return dp[m, n];
        }

        public static int[] CountZeroesOnes(string s)
        {
            int[] count = new int[2];
            for(int i = 0; i < s.Length; i++)
                if (s[i] == '0')
                    count[0]++;
                else count[1]++;
            return count;
        }
    }
}
