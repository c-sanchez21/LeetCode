using System;

namespace _122._Best_Time_to_Buy_and_Sell_Stock_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
            Console.WriteLine(MaxProfit(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(MaxProfit(new int[] { 7, 6, 4, 3, 1 }));
            Console.WriteLine(MaxProfit(new int[] { 1, 2 }));
            Console.WriteLine(MaxProfit(new int[] { 2, 1, 4 }));
        }

        public static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2) return 0;
            if (prices.Length == 2 && prices[0] < prices[1]) return (prices[1] - prices[0]);

            int idx = 0;
            int min = prices[0];
            int max = prices[0];
            long profit = 0;
            while (idx < prices.Length - 1)
            {
                //Find Dip
                while (idx < prices.Length - 1 && prices[idx] >= prices[idx + 1])
                    idx++;
                min = prices[idx];
                //Find Peak
                while (idx < prices.Length - 1 && prices[idx] <= prices[idx + 1])
                    idx++;
                max = prices[idx];
                profit += (max - min);
            }

            return (int)profit;
        }
    }
}
