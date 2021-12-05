using System;
using System.Collections.Generic;
using System.Text;

//https://leetcode.com/problems/stream-of-characters/

namespace _1032._Stream_of_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ["StreamChecker", "query", "query", "query", "query", "query", "query", "query", "query", "query", "query", "query", "query"]
            [[["cd", "f", "kl"]], ["a"], ["b"], ["c"], ["d"], ["e"], ["f"], ["g"], ["h"], ["i"], ["j"], ["k"], ["l"]]
            Output
            [null, false, false, false, true, false, true, false, false, false, false, false, true]

            Explanation
            StreamChecker streamChecker = new StreamChecker(["cd", "f", "kl"]);
            streamChecker.query("a"); // return False
            streamChecker.query("b"); // return False
            streamChecker.query("c"); // return False
            streamChecker.query("d"); // return True, because 'cd' is in the wordlist
            streamChecker.query("e"); // return False
            streamChecker.query("f"); // return True, because 'f' is in the wordlist
            streamChecker.query("g"); // return False
            streamChecker.query("h"); // return False
            streamChecker.query("i"); // return False
            streamChecker.query("j"); // return False
            streamChecker.query("k"); // return False
            streamChecker.query("l"); // return True, because 'kl' is in the wordlist
            */
        }

        public class TrieNode //Trie DataStructure - Implemented as Nested HashMaps
        {
            public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
            public bool Word = false; //If the node is an actual word. 
        }
        public class StreamChecker
        {
            TrieNode trie = new TrieNode(); //Root TrieNode
            List<char> stream = new List<char>(); //Our current stream of characters

            public StreamChecker(string[] words)
            {
                //Put all the words (in reverse) into our Trie
                foreach (String word in words)
                {
                    TrieNode node = trie; //Set root

                    //Reverse the word 
                    char[] charRev = word.ToCharArray();
                    Array.Reverse(charRev);
                    String reversedWord = new string(charRev);

                    //Put each letter into the trie
                    foreach (char ch in reversedWord.ToCharArray())
                    {
                        if (!node.Children.ContainsKey(ch))
                            node.Children.Add(ch, new TrieNode());
                        node = node.Children[ch];
                    }

                    //Mark the last node/letter as completing a word. 
                    node.Word = true;
                }
            }

            //Checks if the suffix of the stream completes a word
            public bool Query(char letter)
            {
                stream.Add(letter);//Add a letter to the end 

                TrieNode node = trie; //Set trie node to root; 
                char ch;

                //Check if the stream suffix completes a word
                for (int i = stream.Count - 1; i >= 0; i--)
                {
                    ch = stream[i];
                    if (node.Word) //If the current node is a word return true
                        return true;
                  
                    if (!node.Children.ContainsKey(ch))
                        return false; //If cannot go any further return false
                    
                    node = node.Children[ch]; //Get the next trie node
                }

                return node.Word; //Return wheter the last trie node was a word or not. 
            }
        }
    }
}
