//https://leetcode.com/problems/maximum-value-of-k-coins-from-piles/
Console.WriteLine("Hello, World!");

int MaxValueOfCoins(IList<IList<int>> piles, int k)
{
    int n = piles.Count;
    int[,] dp = new int[n + 1, k + 1];
    int currentSum;
    for(int i =1; i <= n; i++)
    {
        for (int coins = 0; coins <= k; coins++)
        {
            currentSum = 0;
            for (int currentCoins = 0; currentCoins <= Math.Min(piles[i - 1].Count, coins); currentCoins++)
            {
                if (currentCoins > 0)
                {
                    currentSum += piles[i - 1][currentCoins - 1];
                }
                dp[i, coins] = Math.Max(dp[i, coins], dp[i - 1, coins - currentCoins] + currentSum);

            }
        }
    }
    return dp[n, k];
}