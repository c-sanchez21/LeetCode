using System;
using System.Collections.Generic;

namespace FirstUniqueCharacterInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = { "leetcode", "loveleetcode" };
            foreach (string input in inputs)
                Console.WriteLine("{0} = {1}", input, FirstUniqChar(input));
        }

        public static int FirstUniqChar(string s)
        {
            if (String.IsNullOrEmpty(s)) return -1;
            Dictionary<char,int> map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else map.Add(c, 1);
            }
            for (int i = 0; i < s.Length; i++)
                if (map.ContainsKey(s[i]) && map[s[i]] == 1)
                    return i;
            return -1;
        }
    }
}
