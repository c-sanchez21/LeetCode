//https://leetcode.com/problems/number-of-ways-to-form-a-target-string-given-a-dictionary/
Console.WriteLine("Hello, World!");

int NumWays(string[] words, string target)
{
    int letters = 26;
    int mod = 1000000007;
    int m = target.Length;
    int k = words[0].Length;
    int[,] count = new int[letters, k];

    for(int j = 0; j < k; j++)
        foreach(string word in words)
            count[word[j] - 'a', j]++;
    long[,] dp = new long[m + 1, k + 1];
    dp[0, 0] = 1;
    for(int i = 0; i <= m; i++)
        for(int j = 0; j < k; j++)
        {
            if(i < m)
            {
                dp[i + 1, j + 1] += count[target[i] - 'a', j] * dp[i, j];
                dp[i + 1, j + 1] %= mod;
            }
            dp[i, j + 1] += dp[i, j];
            dp[i,j+1] %= mod;
        }
    return (int)dp[m, k];

}
