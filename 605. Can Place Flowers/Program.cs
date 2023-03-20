using System;

namespace _605._Can_Place_Flowers
{
    //https://leetcode.com/problems/can-place-flowers/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanPlaceFlowers(new int[] { 0, 0, 0, 0, 0 }, 3));
        }

        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int i = 0, count = 0;
            while (i < flowerbed.Length)
            {
                if (flowerbed[i] == 0 && //Current == 0;
                    (i == 0 || flowerbed[i - 1] == 0) && //Is Beginning or Previous == 0
                    (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0)) //Is Last or Next == 0
                {
                    flowerbed[i] = 1;
                    count++;
                }
                i++;
            }
            return count >= n;
        }
    }
}
