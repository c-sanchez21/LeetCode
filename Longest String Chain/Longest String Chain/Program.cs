using System;
using System.Collections.Generic;

namespace Longest_String_Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int ans = 1;//Default longest chain is 1
        public int LongestStrChain(string[] words)
        {
            //Check for null and empty
            if (words == null || words.Length == 0) return 0;

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();//Holds paths for each word

            //Sort words by length

            //Check words for predecessor 
            for (int i = 0; i < words.Length-1;i++)
            {
                for(int j = i+1; j < words.Length;j++)
                {
                    if (words[i].Length == words[j].Length)
                        continue; //Skip words of same length
                    else if (words[i].Length + 1 < words[j].Length)
                        break; //words[j] is too big and cannot be successor. 
                    else if(IsPredecessor(words[i], words[j]))
                    {
                        //If word has sucessor then map the paths each word can take
                        if (!map.ContainsKey(words[i]))
                            map.Add(words[i], new List<string>());
                        map[words[i]].Add(words[j]);
                    }
                }
            }

          
            foreach(string s in words)
                DFS(s, map, 0); //Depth first search for the longest path;

            return ans; 
        }

        static Dictionary<string, int> cache = new Dictionary<string, int>();//Memoization for longest string chain
        public static int DFS(string s, Dictionary<string,List<string>> map, int depth)
        {
            if (cache.ContainsKey(s))
                return depth += cache[s];

            int max = depth + 1;
            if (map.ContainsKey(s))
            {
                foreach (string s2 in map[s])
                {
                    int tmp = DFS(s2, map, depth + 1);
                }
            }
        }
        public static bool IsPredecessor(string s1, string s2)
        {

        }
    }
}
