//https://leetcode.com/problems/removing-stars-from-a-string/

using System.Text;
Console.WriteLine(RemoveStars("leet**cod*e"));;
Console.WriteLine(RemoveStars("sea***")); ;

string RemoveStars(string s)
{
    Stack<char> chars = new Stack<char>();
    foreach(char c in s)
    {
        if (c == '*')
            chars.Pop();
        else chars.Push(c);
    }
    StringBuilder sb = new StringBuilder();
    while(chars.Count > 0)
        sb.Insert(0,chars.Pop());
    return sb.ToString();
}

//Time Limit Exceeded 
string RemoveStars2(string s)
{
    StringBuilder sb = new StringBuilder(s);
    int idx = 0;
    while (idx < sb.Length)
    {
        if (sb[idx] == '*')
        {
            //sea***
            //idx = 3;
            sb.Remove(idx, 1);
            sb.Remove(idx - 1, 1);
            idx--;
        }
        else idx++;
    }
    return sb.ToString();
}