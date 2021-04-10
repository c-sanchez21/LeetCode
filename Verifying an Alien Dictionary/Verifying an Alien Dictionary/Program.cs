using System;
using System.Collections.Generic;

namespace Verifying_an_Alien_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool ans1 = IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz");
            bool ans2 = IsAlienSorted(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz");
            bool ans3 = IsAlienSorted(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz");
            Console.WriteLine(ans1);
            Console.WriteLine(ans2);
            Console.WriteLine(ans3);
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            //Put alphabet into lexicon order dictionary
            Dictionary<char, int> lexiOrder = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
                if (!lexiOrder.ContainsKey(order[i]))
                    lexiOrder.Add(order[i], i);

            //Check if words are sorted
            for(int i = 0; i < words.Length-1; i++)
            {
                for(int j = i+1; j < words.Length; j++)
                {
                    string A = words[i];
                    string B = words[j];

                    //Get the lesser length of the two strings
                    int lesser = A.Length < B.Length ? A.Length : B.Length;
                    int ordA, ordB;
                    //Compare the two strings
                    int idx; 
                    for (idx = 0; idx < lesser; idx++)
                    {
                        ordA = lexiOrder[A[idx]];
                        ordB = lexiOrder[B[idx]];

                        //if the order of the two chars is not the same:
                        if (ordA != ordB)
                        {
                            //A[idx] comes after B[idx]
                            if (ordA > ordB)
                                return false; //Words are unsorted
                            else break;
                        }
                    }

                    //Same prefix but A is larger so they are unsorted
                    if (idx == lesser && B.Length < A.Length)
                        return false;
                }
            }
            return true;//Words are sorted
        }
    }
}
