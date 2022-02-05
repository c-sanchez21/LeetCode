using System;

namespace _1561._Maximum_Number_of_Coins_You_Can_Get
{
    class Program
    {
        //https://leetcode.com/problems/maximum-number-of-coins-you-can-get/
        static void Main(string[] args)
        {
            //Example 1: 
            Console.WriteLine(MaxCoins(new int[] { 2, 4, 1, 2, 7, 8 }));
        }

        public static int MaxCoins(int[] piles)
        {
            //Sort the array - Sorts Ascending
            Array.Sort(piles);

            //Find the max amount of coins you can take 
            int j = piles.Length - 1;
            int i = 0;
            int coins = 0;
            while (i < j)
            {
                j--;//Alice takes her cut from the highest pile
                coins += piles[j--];//Take your share from the 2nd highest
                i++; //Bob gets the short end of the stick.
            }
            return coins;
        }
    }
}
