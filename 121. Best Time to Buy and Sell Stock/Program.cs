using System;

namespace _121._Best_Time_to_Buy_and_Sell_Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Cases
            Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
            Console.WriteLine(MaxProfit(new int[] { 7, 6, 4, 3, 1 }));
            Console.WriteLine(MaxProfit(new int[] { 2,6,1,2,2,3 }));

        }

        public static int MaxProfit(int[] prices)
        {
            //Check for invalid input
            if (prices == null || prices.Length == 0) return 0;

            int min = prices[0]; //Current min price
            int maxProfit = 0; //Current max profit

            //Find the max profit
            for(int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > min) //Update the maxProfit
                    maxProfit = Math.Max(prices[i] - min, maxProfit);
                else min = prices[i];//Or else update the new min
            }

            return maxProfit;
        }
    }
}
