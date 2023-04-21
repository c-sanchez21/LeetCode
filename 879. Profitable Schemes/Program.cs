//https://leetcode.com/problems/profitable-schemes/

Console.WriteLine("Hello, World!");
const int mod = 1000000007;
int[,,] cache = new int[101, 101, 101];

int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
{
    for (int i = 0; i <= group.Length; i++)
        for (int j = 0; j <= n; j++)
            for (int k = 0; k <= 100; k++)
                cache[i, j, k] = -1;
    return Find(0,0,0,n,minProfit,group, profit);
}


int Find(int pos, int count, int profit, int n, int minProfit, int[] group, int[] profits)
{
    if (pos == group.Length) return profit >= minProfit ? 1 : 0;

    if (cache[pos, count, profit] != -1) return cache[pos, count, profit];

    int totalWays = Find(pos+1,count, profit, n, minProfit, group, profits);
    if (count + group[pos] <= n)
            totalWays += Find(pos + 1, count + group[pos],
            Math.Min(minProfit, profit + profits[pos]), n, minProfit, group, profits);
  
    return cache[pos, count, profit] = totalWays % mod;
}

