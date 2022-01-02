using System;
using System.Collections.Generic;

namespace _1010._Pairs_of_Songs_With_Total_Durations_Divisible_by_60
{
    //https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumPairsDivisibleBy60(
                new int[] { 30, 20, 150, 100, 40 }));
        }

        public static int NumPairsDivisibleBy60(int[] time)
        {
            int[] mods = new int[60];
            int pairs = 0;
            int rem; //remainder
            foreach (int t in time)
            {
                //If song is already 60 seconds 
                rem = t % 60;
                if (rem == 0)
                    pairs += mods[0]; //Can pair with any other song that is a multiple of 60
                //Else Pair with any other song that adds up to multiple of 60 
                else
                    pairs += mods[60 - rem];
                mods[rem]++; //Update remainders
            }
            return pairs;
        }
    }
}
