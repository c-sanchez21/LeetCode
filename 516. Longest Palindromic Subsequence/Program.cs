//https://leetcode.com/problems/longest-palindromic-subsequence/

using System.Globalization;

Console.WriteLine(LongestPalindromeSubseq("bbbab"));

int[,] cache;
int LongestPalindromeSubseq(string s)
{
    int n = s.Length;
    cache = new int[n, n];
    return LPS(s, 0, n - 1);
}


int LPS(string s, int i, int j)
{
    if (cache[i,j] != 0) return cache[i,j];
    
    if(i > j) return 0;

    if(i == j) return 1;

    if (s[i] == s[j])
        cache[i, j] = LPS(s, i + 1, j - 1) + 2;
    else cache[i,j] = Math.Max(LPS(s,i+1,j), LPS(s,i,j-1));

    return cache[i,j];
}