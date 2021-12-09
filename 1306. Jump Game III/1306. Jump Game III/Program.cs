using System;

namespace _1306._Jump_Game_III
{
    class Program
    {
        //https://leetcode.com/problems/jump-game-iii/
        static void Main(string[] args)
        {
            Console.WriteLine(CanReach(new int[] { 4, 2, 3, 0, 3, 1, 2 },5));
        }

        //Depth First Search
        public static bool CanReach(int[] arr, int start)
        {
            //Check for out of bounds or already visited
            if (start >= 0 && start < arr.Length && arr[start] >= 0)
            {
                //Target found - return true
                if (arr[start] == 0) return true;

                //Mark as visisted
                arr[start] = arr[start] * -1;

                //Depth First Search 
                return CanReach(arr, start + arr[start]) || CanReach(arr, start - arr[start]);
            }
            return false;
        }
    }
}
