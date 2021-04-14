using System;
using System.Collections.Generic;

namespace Word_Ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>(new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            int steps = LadderLength("hit", "cog", list);
            Console.WriteLine(steps);
            Console.WriteLine(LadderLength("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log" }));
            Console.WriteLine(LadderLength("hot", "dog", new string[] { "hot", "cog", "dog", "tot", "hog", "hop", "pot", "dot" }));
            Console.WriteLine(LadderLength("a", "c", new string[] { "a", "b", "c" }));
        }

        //Breadth First Search
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            //Base Case
            if (!wordList.Contains(endWord)) return 0;
            if (beginWord.Equals(endWord)) return 1;

            //A Set containing words not yet visited
            HashSet<string> words = new HashSet<string>(wordList);
            
            //Initialize Queue with beginWord
            Queue<string> q = new Queue<string>();
            int steps = 1;
            words.Remove(beginWord);
            q.Enqueue(beginWord);
            q.Enqueue(""); //Insert delimiter denoting another level of BFS

            string curWord;
            while(q.Count > 0)
            {
                curWord = q.Dequeue();

                if(string.IsNullOrEmpty(curWord))
                {//Reached another level of BFS
                    if(q.Count > 0)
                    {
                        q.Enqueue("");
                        steps++;
                    }
                }
                else
                {
                    //Grab all the adjacent words 
                    HashSet<string> neighbors = Neighbors(words, curWord);
                    if (neighbors.Contains(endWord))
                        return (steps + 1);//If found return number of steps
                    
                    //Enqueue neighboring words while marking them as "visited" 
                    foreach (string s in neighbors)
                    {
                        words.Remove(s);
                        q.Enqueue(s);
                    }
                }
            }
            return 0;
        }

        //Find words that differ by 1 char
        public static HashSet<string> Neighbors(HashSet<string> wordPool, string word)
        {
            HashSet<string> results = new HashSet<string>();
            //Compare word with each word in the wordpool 
            foreach(string s in wordPool)
            {
                //Count the number of differences
                int count = 0;
                for(int i = 0; i < s.Length; i++)
                {
                    if (word[i] != s[i])
                        count++;
                    if (count > 1) continue;//If more than 1 difference then stop comparing
                }
                if (count == 1) //If only 1 char difference add to results list
                    results.Add(s);
            }
            return results;
        }
    }
}
