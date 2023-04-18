//https://leetcode.com/problems/merge-strings-alternately/using System.Text;

using System.Text;

Console.WriteLine(MergeAlternately("abc", "pqr"));

string MergeAlternately(string word1, string word2)
{
    int m = word1.Length;
    int n = word2.Length;
    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < Math.Max(m,n); i++)
    {
        if (i < m) sb.Append(word1[i]);
        if (i < n) sb.Append(word2[i]);
    }
    return sb.ToString();
}