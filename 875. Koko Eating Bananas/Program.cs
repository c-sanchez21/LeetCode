using System;

namespace _875._Koko_Eating_Bananas
{
    class Program
    {
        //https://leetcode.com/problems/koko-eating-bananas/
        static void Main(string[] args)
        {
            Console.WriteLine(MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 8));//4
        }

        public static int MinEatingSpeed(int[] piles, int h)
        {
            int min = 1; //Minimum Speed
            int max = 1; //Max Speed requred;
            //Find the max number from the piles
            foreach (int pileCount in piles)
                max = Math.Max(max, pileCount);

            //Binary Search for Min Speed
            int mid, hours;
            while(min < max)
            {
                mid = (min + max) / 2; //Try mid working speed;
                hours = 0;

                //Check hours needed to consume all piles
                foreach(int pileCount in piles)
                    hours += (int)Math.Ceiling((double)pileCount / mid);

                //Check if mid speed works
                if (hours <= h)
                    max = mid;
                else
                    min = mid + 1;
            }

            //Min Speed found when min == max. 
            return max;

        }
    }
}
