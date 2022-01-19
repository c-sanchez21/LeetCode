using System;

namespace _605._Can_Place_Flowers
{
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
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
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
