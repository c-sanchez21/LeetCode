using System;
using System.Collections.Generic;

namespace _380._Insert_Delete_GetRandom_O_1_
{
    class Program
    {
        //https://leetcode.com/problems/insert-delete-getrandom-o1/
        static void Main(string[] args)
        {
            RandomizedSet rSet = new RandomizedSet();
            for (int i = 0; i <= 10; i++)
                rSet.Insert(i);
            for (int i = 0; i < 3; i++)
                Console.WriteLine("Random Num: {0}", rSet.GetRandom());
            for (int i = 0; i < 7; i++)
                rSet.Remove(rSet.GetRandom());
            Console.WriteLine("Removed 7 random numbers.");
            for (int i = 0; i < 3; i++)
                Console.WriteLine("Random Num: {0}", rSet.GetRandom());
        }

        public class RandomizedSet
        {
            HashSet<int> nums = new HashSet<int>();
            Random randGen = new Random();
            public RandomizedSet()
            {
                nums = new HashSet<int>();
            }

            public bool Insert(int val)
            {
                bool has = nums.Contains(val);
                nums.Add(val);
                return !has;
            }

            public bool Remove(int val)
            {
                bool has = nums.Contains(val);
                if(has) nums.Remove(val);
                return has;
            }

            public int GetRandom()
            {
                int randIdx = randGen.Next(0, nums.Count);
                int[] arr = new int[nums.Count];
                nums.CopyTo(arr);
                return arr[randIdx];
            }
        }
    }
}
