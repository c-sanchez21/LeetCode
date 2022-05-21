using System;
using System.Collections.Generic;
using System.Linq;

namespace _322._Coin_Change
{
    //https://leetcode.com/problems/coin-change/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CoinChange(new int[] { 1, 2, 5 }, 11));
            Console.WriteLine(CoinChange(new int[] { 2 }, 3));
            Console.WriteLine(CoinChange(new int[] { 1 }, 0));
            Console.WriteLine(CoinChange(new int[] { 186, 419, 83, 408 }, 6249)); //20
        }

        public static int CoinChange(int[] coins, int amount)
        {
            if (amount < 1) return 0;
            return FindMin(amount, coins, new int[amount + 1]);
        }
        public static int FindMin(int amt, int[] coins, int[] cache)
        {
            if (amt < 0) return -1;
            if (amt == 0) return 0;
            if (cache[amt] != 0) return cache[amt];
            int min = int.MaxValue;
            foreach (int coin in coins)
            {
                int res = FindMin(amt - coin, coins, cache);
                if (res >= 0 && res < min)
                    min = res + 1;
            }
            cache[amt] = (min == int.MaxValue) ? -1 : min;
            return cache[amt];
        }
    }
}
