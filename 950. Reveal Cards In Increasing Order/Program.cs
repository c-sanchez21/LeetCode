using System;
using System.Collections.Generic;

namespace _950._Reveal_Cards_In_Increasing_Order
{
    class Program
    {
        //https://leetcode.com/problems/reveal-cards-in-increasing-order/
        static void Main(string[] args)
        {
            Console.WriteLine(
                String.Join(" ",DeckRevealedIncreasing(new int[] { 17, 13, 11, 2, 3, 5, 7 })));
        }

        public static int[] DeckRevealedIncreasing(int[] deck)
        {
            //Sort the Deck
            Array.Sort(deck);

            //Utilize a Queue to store indexes
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < deck.Length; i++)
                q.Enqueue(i);

            //Variables
            int[] results = new int[deck.Length];
            int idx = 0; //Index
            int n = 0;//Place in
            
            //While indexes are available grab top
            //and store in reults, shuffle the next index to bottom 
            //repeat until only 1 card left. 
            while (q.Count > 1) 
            {
                idx = q.Dequeue(); //Grab Index from Queue
                results[idx] = deck[n++];//Store card in results 
                q.Enqueue(q.Dequeue()); //Take from top and shuffle to bottom
            }
            results[q.Dequeue()] = deck[n];//Insert last card into the deck. 
            return results;
        }
    }
}
