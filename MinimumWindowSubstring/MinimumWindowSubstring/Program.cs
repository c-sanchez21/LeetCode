using System;
using System.Collections.Generic;

namespace MinimumWindowSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));
            Console.WriteLine(MinWindow("a", "a"));
        }

        //Sliding Window Method
        public static string MinWindow(string s, string t)
        {
            //Put string T into a hashmap of needed counts
            Dictionary<char, int> needed = new Dictionary<char, int>();
            foreach (char ch in t)
            {
                if (needed.ContainsKey(ch))
                    needed[ch]++;
                else needed.Add(ch, 1);
            }
            int unique = needed.Keys.Count;
            int uniCount = 0;//How many unique keys are satisfied

            int l, r; //Left and Right index
            l = r = 0;
            string ans = "";
            int minSize = int.MaxValue; //Minimun Window Size
            int size = 0; 

            //Keep track of the char count in our current window
            Dictionary<char, int> curCount = new Dictionary<char, int>();
            char c;
            while (r < s.Length)
            {
                c = s[r];

                if (curCount.ContainsKey(c))
                    curCount[c]++;
                else curCount.Add(c, 1);

                if (needed.ContainsKey(c) && curCount[c] == needed[c])
                    uniCount++;

                //If window is satisfied then start sliding from the left
                //to possibly find a smaller window
                while (l <= r && uniCount == unique)
                {
                    size = r - l + 1;
                    if (size < minSize)
                    {
                        ans = s.Substring(l, size);
                        minSize = size;
                    }

                    //Remove char from the left
                    c = s[l];
                    curCount[c]--;
                    if (needed.ContainsKey(c) && curCount[c] < needed[c])
                        uniCount--;
                    l++;
                }
                r++;
            }

            return ans;
        }
    }
}
